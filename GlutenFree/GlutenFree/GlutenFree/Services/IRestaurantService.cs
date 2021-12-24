using GlutenFree.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlutenFree.Services
{
    public interface IRestaurantService
    {
        //Task<IEnumerable<Restaurant>> RefreshRestaurantsAsync();
        Task<IEnumerable<Restaurant>> GetRestaurantsAsync();
        Task AddRestaurantAsync(string name, string address, string city, string province, string region, 
            double latitude, double longitude, string dishType, int specialMenu);
        Task<Restaurant> GetRestaurantAsync(int id);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncName(string name);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncCity(string city);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncProvince(string province);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncRegion(string region);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncDishType(string dishType);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncSpecialMenu(int specialMenu);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncCityDishType(string city, string dishType);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncCityDishTypeSpecialMenu(string city, string dishType, int specialMenu);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncProvinceDishType(string province, string dishType);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncProvinceDishTypeSpecialMenu(string province, string dishType, int specialMenu);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncRegionDishType(string region, string dishType);
        Task<IEnumerable<Restaurant>> GetRestaurantAsyncRegionDishTypeSpecialMenu(string region, string dishType, int specialMenu);
        Task DeleteRestaurantAsync(int id);
    }
}
