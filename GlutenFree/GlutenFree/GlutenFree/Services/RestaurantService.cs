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
        readonly Random rnd = new Random();

        async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Restaurants.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Ristorante>();
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantsAsync()
        {
            await Init();

            var restaurant = await db.Table<Ristorante>().ToListAsync();
            return restaurant;
        }

        public async Task AddRestaurantAsync(string name, string address, string city, string province, string region, double latitude, double longitude, string dishType, int specialMenu)
        {
            await Init();
            var generatedRandomInt = rnd.Next(10, 9999999);
            var restaurant = new Ristorante()
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
                TipoCucina = new TipologieCucina
                {
                    Principale=dishType
                },
                MenuAParte = specialMenu,
                ImageId = generatedRandomInt + 3

            };

            var id = await db.InsertAsync(restaurant);
        }

        public async Task<Ristorante> GetRestaurantAsync(int id)
        {
            await Init();

            var restaurant = await db.Table<Ristorante>()
                .FirstOrDefaultAsync(r => r.Id == id);

            return restaurant;
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            await Init();

            await db.DeleteAsync<Ristorante>(id);
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncName(string name)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.Nome.Equals(name))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncCity(string city)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.Città.Equals(city))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncProvince(string province)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.Provincia.Equals(province))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncRegion(string region)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.Regione.Equals(region))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncDishType(string dishType)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncSpecialMenu(int specialMenu)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncCityDishType(string city, string dishType)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.Città.Equals(city))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncCityDishTypeSpecialMenu(string city, string dishType, int specialMenu)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.Città.Equals(city))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncProvinceDishType(string province, string dishType)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.Provincia.Equals(province))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncProvinceDishTypeSpecialMenu(string province, string dishType, int specialMenu)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.Provincia.Equals(province))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncRegionDishType(string region, string dishType)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.Regione.Equals(region))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<Ristorante>> GetRestaurantAsyncRegionDishTypeSpecialMenu(string region, string dishType, int specialMenu)
        {
            await Init();
            List<Ristorante> restaurants = await db.Table<Ristorante>()
                .Where(r => r.Regione.Equals(region))
                .Where(r => r.TipoCucina.Principale.Equals(dishType))
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
            return restaurants;
        }
    }
}