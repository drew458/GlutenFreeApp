using GlutenFreeApp.Models;
using System.Collections.Generic;

namespace GlutenFreeApp.Services
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
                        Nome = restaurantFromQuery.Provincia
                    },
                    Regione = new Regione
                    {
                        Nome = restaurantFromQuery.Provincia
                    },
                    Latitudine = restaurantFromQuery.Latitudine,
                    Longitudine = restaurantFromQuery.Longitudine,
                    TipoCucina = restaurantFromQuery.TipoCucina,
                    MenuAParte = restaurantFromQuery.MenuAParte,
                    ImageId = restaurantFromQuery.ImageId,
                    Posizione = new Xamarin.Forms.Maps.Position(restaurantFromQuery.Latitudine, restaurantFromQuery.Longitudine),
                    URL = restaurantFromQuery.URL
                });
            }

            return restaurants;
        }

        public static Restaurant Convert(RestaurantFromQuery restaurantFromQuery)
        {
            Restaurant restaurant = new Restaurant
            {
                ID = restaurantFromQuery.ID,
                Nome = restaurantFromQuery.Nome,
                Indirizzo = restaurantFromQuery.Indirizzo,
                Citta = restaurantFromQuery.Citta,
                Provincia = new Provincia
                {
                    Nome = restaurantFromQuery.Provincia
                },
                Regione = new Regione
                {
                    Nome = restaurantFromQuery.Regione
                },
                Latitudine = restaurantFromQuery.Latitudine,
                Longitudine = restaurantFromQuery.Longitudine,
                TipoCucina = restaurantFromQuery.TipoCucina,
                MenuAParte = restaurantFromQuery.MenuAParte,
                ImageId = restaurantFromQuery.ImageId,
                Posizione = new Xamarin.Forms.Maps.Position(restaurantFromQuery.Latitudine, restaurantFromQuery.Longitudine),
                URL = restaurantFromQuery.URL
            };

            return restaurant;
        }

    }
}
