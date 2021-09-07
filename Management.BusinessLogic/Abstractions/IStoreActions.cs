using Management.Models;
using Management.Data;
using Management.Data.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Management.Data.DTOs.StoreDTOs;
using Microsoft.EntityFrameworkCore;

namespace Management.BusinessLogic
{
    public interface IStoreActions
    {
        Task<Store> CreateStore(string storeName, string storeNumber, string storeType, int storeProducts, string userId);
        Task<Store> GetStore(string storeId);
        Task<List<Store>> GetAllStores();
        Task<List<Store>> GetAllStoresBelongingToAUser(string userId);
        Task<bool> UpdateStoreUsingPut(PutStoreRequest storeDTO, string storeId, string userId);
        Task<bool> UpdateStoreUsingPatch(PatchStoreRequest storeDTO, string Id, string userId);
        Task<bool> RemoveStore(string storeId, string userId);
    }
}