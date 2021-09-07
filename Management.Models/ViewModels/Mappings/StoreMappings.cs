using System;
using System.Collections.Generic;
using System.Text;
using Management.Models.ViewModels.VM;

namespace Management.Models.ViewModels.Mappings
{
    public class StoreMappings
    {
        public static List<StoresVM> GetAllStoresForDisplay(List<Store> stores)
        {
            var storesVM = new List<StoresVM>();
            foreach (var store in stores)
            {
                storesVM.Add(
                    new StoresVM
                    {
                        Id = store.Id,
                        StoreName = store.StoreName,
                        StoreNumber= store.StoreNumber,
                        StoreType = store.StoreType,
                        StoreProducts = store.StoreProducts,
                        ImageUrl = store.ImageUrl
                    }
                );
                
            }
            return storesVM;
        }

        public static List<StoresUsersVM> GetStoresForAUser(List<Store> stores)
        {
            var storeUsersVM = new List<StoresUsersVM>();
            foreach (var store in stores)
            {
                storeUsersVM.Add(
                    new StoresUsersVM
                    {
                        Id = store.Id,
                        UserId = store.UserId,
                        StoreName = store.StoreName,
                        StoreNumber= store.StoreNumber,
                        StoreType = store.StoreType,
                        StoreProducts = store.StoreProducts,
                        ImageUrl = store.ImageUrl
                    }
                );
            }
            return storeUsersVM;
        }

        public static StoreVM GetStore(Store store)
        {
            return new StoreVM
            {
                Id = store.Id,
                StoreName = store.StoreName,
                StoreNumber= store.StoreNumber,
                StoreType = store.StoreType,
                StoreProducts = store.StoreProducts,
                ImageUrl = store.ImageUrl
            };
        }
    }
}