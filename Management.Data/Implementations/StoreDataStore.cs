using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Management.Models;

namespace Management.Data
{
    public class StoreDataStore : IStoreDataStore
    {
        private readonly StoreDbContext _context;

        public StoreDataStore(StoreDbContext context)
        {
            _context = context;
        }

        //add store to database
        public async Task<Store> AddStore(Store store)
        {
            try
            {
                await _context.AddAsync(store);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return store;
                }
                return store;
            }
            catch (Exception e)
            {             
                throw new Exception(e.Message);
            }       
        }

        //get details of a store
        public async Task<Store> GetStore(string storeId)
        {
            try
            {
                Store store = await _context.Stores.FirstOrDefaultAsync(store => store.Id == storeId);
                if (store is null)
                {
                    throw new ArgumentNullException("Resource does not exist");
                }
                return store;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //get all stores
        public async Task<List<Store>> GetAllStores()
        {
            return await _context.Stores.ToListAsync();
        }

        //get per user
        public async Task<List<Store>> GetAllPerUser(string userId)
        {
            return await _context.Stores.Where(store => store.UserId == userId).ToListAsync();
        }

        public async Task<bool> UpdateStore(Store store)
        {
            var findStore = await _context.Stores.FirstOrDefaultAsync(store => store.Id == store.Id);
            if (findStore is null)
            {
                return false;
            }
            _context.Stores.Update(store);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        //delete store
        public async Task<bool> DeleteStore(string storeId)
        {
            Store store = await _context.Stores.FirstOrDefaultAsync(store => store.Id == storeId);
            if (store == null)
            {
                return false;
            }
            _context.Remove(store);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}