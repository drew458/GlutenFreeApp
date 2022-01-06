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
        Random rnd = new Random();

        async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Restaurants.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Restaurant>();
        }

        public async Task<IEnumerable<Restaurant>> RefreshRestaurantsAsync()
        {
            await Init();

            var restaurant = await db.Table<Restaurant>().ToListAsync();
            return restaurant;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            await Init();

            var restaurant = await db.Table<Restaurant>().ToListAsync();
            return restaurant;
        }

        public async Task AddRestaurantAsync(string name, string address, string city, string province, string region, double latitude, double longitude, string dishType, bool specialMenu)
        {
            await Init();
            var generatedRandomInt = rnd.Next(10, 9999999);
            var restaurant = new Restaurant()
            {
                Id = generatedRandomInt,
                Nome = name,
                Indirizzo = address,
                Città = city,
                Provincia = new Provincia()
                {
                    Nome = province
                },
                Regione = new Models.Regione()
                {
                    Nome = region
                },
                Latitudine = latitude,
                Longitudine = longitude,
                TipoCucina = dishType,
                MenuAParte = specialMenu,
                ImageId = generatedRandomInt + 3

            };

            var id = await db.InsertAsync(restaurant);
        }

        public async Task<Restaurant> GetRestaurantAsync(int id)
        {
            await Init();

            var restaurant = await db.Table<Restaurant>()
                .FirstOrDefaultAsync(r => r.Id == id);

            return restaurant;
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            await Init();

            await db.DeleteAsync<Restaurant>(id);
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncName(string name)
        {
            await Init();
            List<Restaurant> restaurants = await db.Table<Restaurant>()
                .Where(r => r.Nome.Equals(name));
            return restaurants;
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
