using GlutenFree.Shared.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GlutenFree.Services
{
    public class RestaurantService : IRestaurantService
    {
        SQLiteAsyncConnection db;

        async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Restaurants.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Restaurant>();
        }

        public Task AddRestaurant(string name)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRestaurant(int id)
        {
            await Init();

            await db.DeleteAsync<Restaurant>(id);
        }

        public async Task<Restaurant> GetRestaurant(int id)
        {
            await Init();

            var restaurant = await db.Table<Restaurant>()
                .FirstOrDefaultAsync(c => c.Id == id);

            return restaurant;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            await Init();

            var restaurant = await db.Table<Restaurant>().ToListAsync();
            return restaurant;
        }
    }
}
