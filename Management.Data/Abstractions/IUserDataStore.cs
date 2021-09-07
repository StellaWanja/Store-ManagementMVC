using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Management.Models;
using Management.Data.DTOs;
using Management.Data.DTOs.UserDTOs;
using Management.Data.DTOs.Mappings;

namespace Management.Data
{
    public interface IUserDataStore
    {
        Task<bool> CreateUser(AppUser user, string password);
        Task<AppUser> Login(string email, string password);
        Task<bool> UpdateUser(string userId, UpdateUserRequest updateUser);
        Task<bool> DeleteUser(string userId);
        Task<UserResponseDTO> GetUser(string userId);  
    }
}