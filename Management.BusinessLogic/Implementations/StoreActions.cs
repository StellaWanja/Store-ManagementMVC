using Management.Models;
using Management.Data;
using Management.Data.DTOs;
using Management.Data.DTOs.StoreDTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Management.BusinessLogic
{
    public class StoreActions : IStoreActions
    {
        //actions to collect data from store
        private readonly IStoreDataStore _dataStore;

        public StoreActions(IStoreDataStore dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        //create store method
        public async Task<Store> CreateStore(string storeName, string storeNumber, string storeType, int storeProducts, string userId)
        {
            Store store = new Store
            {
                StoreName = storeName,
                StoreNumber = storeNumber,
                StoreType = storeType,
                StoreProducts = storeProducts,
                UserId = userId
            };
            var result = await _dataStore.AddStore(store);            
            if(result != null)
            {
                return store;
            }
            throw new TimeoutException("Unable to create store instance at this time"); 
        }

        // Get specific stores
        public async Task<Store> GetStore(string storeId)
        {
            return await _dataStore.GetStore(storeId);
        }

        //get all stores
        public async Task<List<Store>> GetAllStores()
        {
            return await _dataStore.GetAllStores();
        }

        //get all stores per user
        public async Task<List<Store>> GetAllStoresBelongingToAUser(string userId)
        {
            return await _dataStore.GetAllPerUser(userId);
        }


        //update an entire resource/store
        public async Task<bool> UpdateStoreUsingPut(PutStoreRequest storeDTO, string storeId, string userId)
        {
            try
            {
                //get the store details
                var store = await GetStore(storeId);
                //if store is null, return false
                if (store == null)
                {
                    return false;
                }
                //if user id doesnt match, throw exception
                if (store.UserId != userId)
                {
                    throw new UnauthorizedAccessException("Forbidden");
                }
                //update every store details
                store.StoreName = storeDTO.StoreName;
                store.StoreNumber = storeDTO.StoreNumber;
                store.StoreType = storeDTO.StoreType;
                store.StoreProducts = storeDTO.StoreProducts;

                return await _dataStore.UpdateStore(store);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //update using patch
        public async Task<bool> UpdateStoreUsingPatch(PatchStoreRequest storeDTO, string storeId, string userId)
        {
            try
            {
                //get the store details
                var store = await GetStore(storeId);
                //if store is null, return false
                if (store == null)
                {
                    return false;
                }
                //if user id doesnt match, throw exception
                if (store.UserId != userId)
                {
                    throw new UnauthorizedAccessException("Forbidden");
                }
                //update only certain details
                //if eg name = new name, then set it to the new name, else set it to previous one
                store.StoreName = storeDTO.StoreName ?? store.StoreName;
                store.StoreNumber = storeDTO.StoreNumber ?? store.StoreNumber;
                store.StoreType = storeDTO.StoreType ?? store.StoreType;
                store.StoreProducts = storeDTO.StoreProducts != 0 ? storeDTO.StoreProducts : store.StoreProducts;

                return await _dataStore.UpdateStore(store);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //remove product method
        public async Task<bool> RemoveStore(string storeId, string userId)
        {
            //get the store
            var result = await GetStore(storeId);
            //only the user can delete the store
            if (result.UserId == userId)
            {
                return await _dataStore.DeleteStore(storeId);
            }
            //else throw exception
            throw new TimeoutException("Unable to create store instance at this time"); 
        }
    }
}