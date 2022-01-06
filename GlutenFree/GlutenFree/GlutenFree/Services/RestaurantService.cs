using GlutenFree.Models;
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

        public Task<IEnumerable<Restaurant>> RefreshRestaurantsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            await Init();

            var restaurant = await db.Table<Restaurant>().ToListAsync();
            return restaurant;
        }

        public Task AddRestaurantAsync(string name, string address, string city, string province, string region, double latitude, double longitude, string dishType, int specialMenu)
        {
            throw new NotImplementedException();
        }

        public async Task<Restaurant> GetRestaurantAsync(int id)
        {
            await Init();

            var restaurant = await db.Table<Restaurant>()
                .FirstOrDefaultAsync(c => c.Id == id);

            return restaurant;
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            await Init();

            await db.DeleteAsync<Restaurant>(id);
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncCity(string city)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncProvince(string province)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncRegion(string region)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncDishType(string dishType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncSpecialMenu(int specialMenu)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncCityDishType(string city, string dishType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncCityDishTypeSpecialMenu(string city, string dishType, int specialMenu)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncProvinceDishType(string province, string dishType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncProvinceDishTypeSpecialMenu(string province, string dishType, int specialMenu)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncRegionDishType(string region, string dishType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantAsyncRegionDishTypeSpecialMenu(string region, string dishType, int specialMenu)
        {
            throw new NotImplementedException();
        }
    }
}
