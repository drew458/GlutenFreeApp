using GlutenFree.Models;
using GlutenFree.Resources;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GlutenFree.Helpers
{
    public class RestaurantsLocalDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<RestaurantsLocalDatabase> Instance = new AsyncLazy<RestaurantsLocalDatabase>(async () =>
        {
            var instance = new RestaurantsLocalDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Restaurant>();
            return instance;
        });

        public RestaurantsLocalDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Restaurant>> GetItemsAsync()
        {
            return Database.Table<Restaurant>().ToListAsync();
        }

        public Task<List<Restaurant>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<Restaurant>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Restaurant> GetItemAsync(int id)
        {
            return Database.Table<Restaurant>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Restaurant restaurant)
        {
            if (restaurant.ID != 0)
            {
                return Database.UpdateAsync(restaurant);
            }
            else
            {
                return Database.InsertAsync(restaurant);
            }
        }

        public Task<int> DeleteItemAsync(Restaurant restaurant)
        {
            return Database.DeleteAsync(restaurant);
        }
    }
}
