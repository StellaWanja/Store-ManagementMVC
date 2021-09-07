using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Management.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Management.Data;

namespace Management.Data
{
    public class Seeder
    {
        
        public async static Task Seed(StoreDbContext dbContext,UserManager<AppUser> userManager)
        {
            //create databse if not existing
            await dbContext.Database.EnsureCreatedAsync();
            //if database is empty
            if (!dbContext.Users.Any())
            {
                //read from the json file
                var userData = await File.ReadAllTextAsync(@"..\Management.Data\Seeder\Users.json");
                List<AppUser> users = JsonConvert.DeserializeObject<List<AppUser>>(userData);

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "P@ssW0rd123");
                }

                await dbContext.AddRangeAsync(users);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Stores.Any())
            {
                var storeData = await File.ReadAllTextAsync(@"..\Management.Data\Seeder\Stores.json");
                List<Store> stores = JsonConvert.DeserializeObject<List<Store>>(storeData);

                foreach (var store in stores)
                {
                    await dbContext.AddAsync(store);
                    await dbContext.SaveChangesAsync();
                }
            } 
        }
    }
}