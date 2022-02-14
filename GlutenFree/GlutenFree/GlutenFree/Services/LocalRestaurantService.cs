using GlutenFree.Helpers;
using GlutenFree.Models;
using GlutenFree.Resources;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlutenFree.Services
{
    public class LocalRestaurantService
    {
        static SQLiteAsyncConnection Database;
        readonly Random rnd = new Random();

        public static readonly AsyncLazy<LocalRestaurantService> Instance = new AsyncLazy<LocalRestaurantService>(async () =>
        {
            var instance = new LocalRestaurantService();
            CreateTableResult result = await Database.CreateTableAsync<Restaurant>();
            return instance;
        });

        public LocalRestaurantService() {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return Database.Table<Restaurant>().ToListAsync();
        }

        public Task AddRestaurantAsync(string name, string address, string city, string province, string region, double latitude, double longitude, string dishType, int specialMenu)
        {
            var generatedRandomInt = rnd.Next(10, 9999999);
            var restaurant = new Restaurant()
            {
                ID = generatedRandomInt,
                Nome = name,
                Indirizzo = address,
                Citta = city,
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
                TipoCucina = new TipologieCucina
                {
                    Principale=dishType
                },
                MenuAParte = specialMenu,
                ImageId = generatedRandomInt + 3

            };

            return Database.InsertAsync(restaurant);
        }

        public Task<Restaurant> GetRestaurantAsync(int id)
        {

            return Database.Table<Restaurant>()
                .FirstOrDefaultAsync(r => r.ID == id);
        }

        public Task DeleteRestaurantAsync(int id)
        {
            return Database.DeleteAsync<Restaurant>(id);
        }

        public Task<List<Restaurant>> GetRestaurantAsyncName(string name)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.Nome.Equals(name))
                .ToListAsync();
        }

        public Task<List<Restaurant>> GetRestaurantAsyncCity(string city)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.Citta.Equals(city))
                .ToListAsync();
        }

        public Task<List<Restaurant>> GetRestaurantAsyncProvince(string province)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.Provincia.Equals(province))
                .ToListAsync();
        }

        public Task<List<Restaurant>> GetRestaurantAsyncRegion(string region)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.Regione.Equals(region))
                .ToListAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantAsyncDishType(string dishType)
        {
            List<Restaurant> restaurants = await Database.Table<Restaurant>()
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .ToListAsync();
            return restaurants;
        }

        public Task<List<Restaurant>> GetRestaurantAsyncSpecialMenu(int specialMenu)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
        }

        public Task<List<Restaurant>> GetRestaurantAsyncCityDishType(string city, string dishType)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.Citta.Equals(city))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .ToListAsync();
        }

        public Task<List<Restaurant>> GetRestaurantAsyncCityDishTypeSpecialMenu(string city, string dishType, int specialMenu)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.Citta.Equals(city))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
        }

        public Task<List<Restaurant>> GetRestaurantAsyncProvinceDishType(string province, string dishType)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.Provincia.Equals(province))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .ToListAsync();
        }

        public Task<List<Restaurant>> GetRestaurantAsyncProvinceDishTypeSpecialMenu(string province, string dishType, int specialMenu)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.Provincia.Equals(province))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
        }

        public Task<List<Restaurant>> GetRestaurantAsyncRegionDishType(string region, string dishType)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.Regione.Equals(region))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .ToListAsync();
        }

        public Task<List<Restaurant>> GetRestaurantAsyncRegionDishTypeSpecialMenu(string region, string dishType, int specialMenu)
        {
            return Database.Table<Restaurant>()
                .Where(r => r.Regione.Equals(region))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
        }
    }
}