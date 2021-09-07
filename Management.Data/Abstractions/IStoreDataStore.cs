using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Management.Models;

namespace Management.Data
{
    //declare methods to use in storedatastore
    public interface IStoreDataStore
    {
        Task<Store> AddStore(Store store);
        Task<Store> GetStore(string storeId);
        Task<List<Store>> GetAllStores();
        Task<List<Store>> GetAllPerUser(string userId);
        Task<bool> UpdateStore(Store store);
        Task<bool> DeleteStore(string storeId);
    }
}