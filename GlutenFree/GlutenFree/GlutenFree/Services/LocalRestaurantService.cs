using GlutenFree.Resources;
using GlutenFreeApp.Helpers;
using GlutenFreeApp.Models;
using GlutenFreeApp.Resources;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlutenFreeApp.Services
{
    public class LocalRestaurantService
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<LocalRestaurantService> Instance = new AsyncLazy<LocalRestaurantService>(async () =>
        {
            var instance = new LocalRestaurantService();
            CreateTableResult result = await Database.CreateTableAsync<RestaurantFromQuery>();
            return instance;
        });

        public LocalRestaurantService() {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantsAsync()
        {
            return Database.Table<RestaurantFromQuery>().ToListAsync();
        }

        public Task<int> AddRestaurantAsync(int id,string name, string address, string city, string province, string region, 
            double latitude, double longitude, string dishType, int specialMenu, int imageId, string url)
        {
            var restaurant = new RestaurantFromQuery()
            {
                ID = id,
                Nome = name,
                Indirizzo = address,
                Citta = city,
                Provincia = province,
                Regione = region,
                Latitudine = latitude,
                Longitudine = longitude,
                TipoCucina = dishType,
                MenuAParte = specialMenu,
                ImageId = imageId,
                URL = url

            };

            var numberOfRows = Database.InsertOrReplaceAsync(restaurant);
            return numberOfRows;
        }

        public Task<RestaurantFromQuery> GetRestaurantAsync(int id)
        {

            return Database.Table<RestaurantFromQuery>()
                .FirstOrDefaultAsync(r => r.ID == id);
        }

        public Task DeleteRestaurantAsync(int id)
        {
            return Database.DeleteAsync<RestaurantFromQuery>(id);
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncName(string name)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.Nome.Equals(name))
                .ToListAsync();
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncCity(string city)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.Citta.Equals(city))
                .ToListAsync();
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncProvince(string province)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.Provincia.Equals(province))
                .ToListAsync();
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncRegion(string region)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.Regione.Equals(region))
                .ToListAsync();
        }

        public async Task<List<RestaurantFromQuery>> GetRestaurantAsyncDishType(string dishType)
        {
            List<RestaurantFromQuery> restaurants = await Database.Table<RestaurantFromQuery>()
                .Where(r => r.TipoCucina.Equals(dishType))
                .ToListAsync();
            return restaurants;
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncSpecialMenu(int specialMenu)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncCityDishType(string city, string dishType)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.Citta.Equals(city))
                //.Where(r => r.TipoCucina.Principale.Equals(dishType))
                .ToListAsync();
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncCityDishTypeSpecialMenu(string city, string dishType, int specialMenu)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.Citta.Equals(city))
                //.Where(r => r.TipoCucina.Principale.Equals(dishType))
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncProvinceDishType(string province, string dishType)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.Provincia.Equals(province))
                //.Where(r => r.TipoCucina.Principale.Equals(dishType))
                .ToListAsync();
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncProvinceDishTypeSpecialMenu(string province, string dishType, int specialMenu)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.Provincia.Equals(province))
                //.Where(r => r.TipoCucina.Equals(dishType))
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncRegionDishType(string region, string dishType)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.Regione.Equals(region))
                //.Where(r => r.TipoCucina.Equals(dishType))
                .ToListAsync();
        }

        public Task<List<RestaurantFromQuery>> GetRestaurantAsyncRegionDishTypeSpecialMenu(string region, string dishType, int specialMenu)
        {
            return Database.Table<RestaurantFromQuery>()
                .Where(r => r.Regione.Equals(region))
                //.Where(r => r.TipoCucina.Equals(dishType))
                .Where(r => r.MenuAParte.Equals(specialMenu))
                .ToListAsync();
        }
    }
}