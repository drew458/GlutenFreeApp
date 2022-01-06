using GlutenFree.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlutenFree.Services
{
    public interface IRestaurantService
    {
        //Task<IEnumerable<Restaurant>> RefreshRestaurantsAsync();
        Task<IEnumerable<Ristorante>> GetRestaurantsAsync();
        Task AddRestaurantAsync(string name, string address, string city, string province, string region, 
            double latitude, double longitude, string dishType, int specialMenu);
        Task<Ristorante> GetRestaurantAsync(int id);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncName(string name);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncCity(string city);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncProvince(string province);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncRegion(string region);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncDishType(string dishType);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncSpecialMenu(int specialMenu);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncCityDishType(string city, string dishType);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncCityDishTypeSpecialMenu(string city, string dishType, int specialMenu);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncProvinceDishType(string province, string dishType);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncProvinceDishTypeSpecialMenu(string province, string dishType, int specialMenu);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncRegionDishType(string region, string dishType);
        Task<IEnumerable<Ristorante>> GetRestaurantAsyncRegionDishTypeSpecialMenu(string region, string dishType, int specialMenu);
        Task DeleteRestaurantAsync(int id);
    }
}
