﻿using GlutenFree.Models;
using System.Collections.Generic;

namespace GlutenFree.Services
{
    public static class RestaurantFromQuery2RestaurantService
    {
        public static List<Restaurant> Convert(IEnumerable<RestaurantFromQuery> restaurantsFromQuery)
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            foreach (var restaurantFromQuery in restaurantsFromQuery)
            {
                restaurants.Add(new Restaurant
                {
                    ID = restaurantFromQuery.ID,
                    Nome = restaurantFromQuery.Nome,
                    Indirizzo = restaurantFromQuery.Indirizzo,
                    Citta = restaurantFromQuery.Citta,
                    Provincia = new Provincia
                    {
                        Nome = restaurantFromQuery.Nome
                    },
                    Regione = new Regione
                    {
                        Nome = restaurantFromQuery.Nome
                    },
                    Latitudine = restaurantFromQuery.Latitudine,
                    Longitudine = restaurantFromQuery.Longitudine,
                    TipoCucina = new TipologieCucina
                    {
                        IdTipoCucina = restaurantFromQuery.IdTipoCucina
                    },
                    MenuAParte = restaurantFromQuery.MenuAParte,
                    ImageId = restaurantFromQuery.ImageId,
                    Posizione = new Xamarin.Forms.Maps.Position(restaurantFromQuery.Latitudine, restaurantFromQuery.Longitudine)
                });
            }

            return restaurants;
        }
    }
}
