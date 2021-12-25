using GlutenFree.Resources;
using GlutenFree.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlutenFree.Services
{
    internal class RemoteRestaurantService : IRestaurantService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;

        public List<Restaurant> Restaurants { get; private set; }
        public Restaurant Restaurant { get; private set; }

        public RemoteRestaurantService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            Restaurants = new List<Restaurant>();

            Uri uri = new Uri(Constants.HTTPUrlGet);
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }

            return Restaurants;
        }

        public async Task AddRestaurantAsync(string name, string address, string city, string province, string region, double latitude, double longitude, string dishType, int specialMenu)
        {
            Uri uri = new Uri(Constants.HTTPUrlCreate);
            try
            {
                /* Add parameter Restaurant restaurant in the method parameters before using
                 * string json = JsonSerializer.Serialize<Restaurant>(restaurant, serializerOptions);
                 * StringContent content = new StringContent(json, Encoding.UTF8, "application/json"); */

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
                {
                    Content = JsonContent.Create(new
                    {
                        name = name,
                        address = address,
                        city = city,
                        province = province,
                        region = region,
                        latitude = latitude,
                        longitude = longitude,
                        dishType = dishType,
                        specialMenu = specialMenu
                    })
                };

                HttpResponseMessage response = await client.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tRistorante aggiunto.");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            string query = Constants.HTTPUrlDelete + "/id={0}";

            Uri uri = new Uri(string.Format(query, id));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tRistorante eliminato.");
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }
        }

        public async Task<Restaurant> GetRestaurantAsync(int id)
        {
            string query = Constants.HTTPUrlGet + "/id={0}";

            Uri uri = new Uri(string.Format(query, id));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurant = JsonSerializer.Deserialize<Restaurant>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }

            return Restaurant;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncName(string name)
        {
            Restaurants = new List<Restaurant>();

            string query = Constants.HTTPUrlGet + "/name={0}";

            Uri uri = new Uri(string.Format(query, name));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncCity(string city)
        {
            Restaurants = new List<Restaurant>();

            string query = Constants.HTTPUrlGet + "/city={0}";

            Uri uri = new Uri(string.Format(query, city));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncProvince(string province)
        {
            Restaurants = new List<Restaurant>();

            string query = Constants.HTTPUrlGet + "/province={0}";

            Uri uri = new Uri(string.Format(query, province));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncRegion(string region)
        {
            Restaurants = new List<Restaurant>();

            string query = Constants.HTTPUrlGet + "/region={0}";

            Uri uri = new Uri(string.Format(query, region));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncDishType(string dishType)
        {
            Restaurants = new List<Restaurant>();

            string query = Constants.HTTPUrlGet + "/dishType={0}";

            Uri uri = new Uri(string.Format(query, dishType));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncSpecialMenu(int specialMenu)
        {
            Restaurants = new List<Restaurant>();

            string query = Constants.HTTPUrlGet + "/specialMenu={0}";

            Uri uri = new Uri(string.Format(query, specialMenu));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncCityDishType(string city, string dishType)
        {
            Restaurants = new List<Restaurant>();

            string query = Constants.HTTPUrlGet + "/city={0}&dishType={1}";

            Uri uri = new Uri(string.Format(query, city, dishType));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncCityDishTypeSpecialMenu(string city, string dishType, int specialMenu)
        {
            Restaurants = new List<Restaurant>();

            object[] parameters = { city, dishType, specialMenu };

            string query = Constants.HTTPUrlGet + "/city={0}&dishType={1}&specialMenu={2}";

            Uri uri = new Uri(string.Format(query, parameters));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncProvinceDishType(string province, string dishType)
        {
            Restaurants = new List<Restaurant>();

            string query = Constants.HTTPUrlGet + "/province={0}&dishType={1}";

            Uri uri = new Uri(string.Format(query, province, dishType));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncProvinceDishTypeSpecialMenu(string province, string dishType, int specialMenu)
        {
            Restaurants = new List<Restaurant>();

            object[] parameters = { province, dishType, specialMenu };

            string query = Constants.HTTPUrlGet + "/province={0}&dishType={1}&specialMenu={2}";

            Uri uri = new Uri(string.Format(query, parameters));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncRegionDishType(string region, string dishType)
        {
            Restaurants = new List<Restaurant>();

            string query = Constants.HTTPUrlGet + "/province={0}&dishType={1}&specialMenu={2}";

            Uri uri = new Uri(string.Format(query, region, dishType));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsyncRegionDishTypeSpecialMenu(string region, string dishType, int specialMenu)
        {
            Restaurants = new List<Restaurant>();

            object[] parameters = { region, dishType, specialMenu };

            string query = Constants.HTTPUrlGet + "/region={0}&dishType={1}&specialMenu={2}";

            Uri uri = new Uri(string.Format(query, parameters));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }
    }
}
