using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Management.Models;
using Management.Data;

namespace Management.BusinessLogic
{
    public class UserActions: IUserActions
    {
        //set user actions to read data from file
        private readonly IUserDataStore _dataStore;
        public UserActions(IUserDataStore dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        //register user method
        //create user object and add it to list<customer>
        public async Task<AppUser> RegisterUser(string firstName, string lastName, string email, string password, string userName)
        {
            AppUser user = new AppUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = string.IsNullOrWhiteSpace(userName) ? email : userName
            };
            var result = await _dataStore.CreateUser(user, password);
            if(true)
            {
                return user;
            }
            throw new TimeoutException("Unable to create user instance at this time");            
        }   

        //login method
        //check if email and password match
        //return values are used to control UI
        public async Task<AppUser> LoginUser(string email, string password)
        {
            var result = await _dataStore.Login(email, password);
            return result;
        }
    }
}
