﻿using GlutenFree.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlutenFree.Services
{
    public interface IRestaurantService
    {
        Task AddRestaurant(string name);
        Task<IEnumerable<Restaurant>> GetRestaurants();
        Task<Restaurant> GetRestaurant(int id);
        Task DeleteRestaurant(int id);
    }
}
