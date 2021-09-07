using System;
using System.Threading.Tasks;
using Management.Models;

namespace  Management.BusinessLogic
{
    public interface IUserActions
    {
        Task<AppUser> RegisterUser(string firstName, string lastName, string email, string password, string userName);
        
        Task<AppUser> LoginUser(string email, string password);
    }
}