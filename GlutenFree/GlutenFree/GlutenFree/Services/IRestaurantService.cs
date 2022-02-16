using GlutenFreeApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlutenFreeApp.Services
{
    public interface IRestaurantService
    {
        //Task<IEnumerable<Restaurant>> RefreshRestaurantsAsync();
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantsAsync();
        Task AddRestaurantAsync(string name, string address, string city, string province, string region, 
            double latitude, double longitude, string dishType, int specialMenu);
        Task<RestaurantFromQuery> GetRestaurantAsync(int id);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncName(string name);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncCity(string city);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncProvince(string province);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncRegion(string region);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncDishType(string dishType);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncSpecialMenu(int specialMenu);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncCityDishType(string city, string dishType);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncCityDishTypeSpecialMenu(string city, string dishType, int specialMenu);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncProvinceDishType(string province, string dishType);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncProvinceDishTypeSpecialMenu(string province, string dishType, int specialMenu);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncRegionDishType(string region, string dishType);
        Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncRegionDishTypeSpecialMenu(string region, string dishType, int specialMenu);
        Task DeleteRestaurantAsync(int id);
    }
}
