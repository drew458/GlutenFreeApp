using GlutenFreeApp.Resources;
using GlutenFreeApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlutenFreeApp.Services
{
    internal class RemoteRestaurantService : IRestaurantService
    {
        readonly HttpClient httpClient;
        readonly JsonSerializerOptions serializerOptions;

        public List<RestaurantFromQuery> Restaurants { get; private set; }
        public RestaurantFromQuery Restaurant { get; private set; }

        public RemoteRestaurantService()
        {
            httpClient = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            };
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantsAsync()
        {
            Restaurants = new List<RestaurantFromQuery>();

            Uri uri = new Uri(Constants.APIRestaurantsGet);
            try
            {
                Restaurants = await httpClient.GetFromJsonAsync<List<RestaurantFromQuery>>(uri, serializerOptions);
                Console.WriteLine(Restaurants);
            }
            catch (HttpRequestException) // Non success
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }

            return Restaurants;
        }

        public async Task AddRestaurantAsync(string name, string address, string city, string province, string region, 
            double latitude, double longitude, string dishType, int specialMenu, int imageId, string url)
        {
            Uri uri = new Uri(Constants.APIRestaurantsCreate);

            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
                {
                    Content = JsonContent.Create(new
                    {
                        name,
                        address,
                        city,
                        province,
                        region,
                        latitude,
                        longitude,
                        dishType,
                        specialMenu,
                        imageId,
                        url
                    })
                };

                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tRestaurant aggiunto.");
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
            string query = Constants.APIRestaurantsDelete + "/id=" +id;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

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

        public async Task<RestaurantFromQuery> GetRestaurantAsync(int id)
        {
            string query = Constants.APIRestaurantsGet + "/id=" +id;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurant = JsonSerializer.Deserialize<RestaurantFromQuery>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }

            return Restaurant;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncName(string name)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/name=" +name;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncCity(string city)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/city=" +city;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncProvince(string province)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/province=" + province;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncRegion(string region)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/region=" + region;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncDishType(string dishType)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/dishType=" + dishType;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncSpecialMenu(int specialMenu)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/specialMenu=" + specialMenu;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncCityDishType(string city, string dishType)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/city=" +city+ "&dishType=" +dishType;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncCityDishTypeSpecialMenu(string city, string dishType, int specialMenu)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/city=" +city+ "&dishType=" +dishType+ 
                "&specialMenu=" +specialMenu;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncProvinceDishType(string province, string dishType)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/province=" +province+ "&dishType=" +dishType;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncProvinceDishTypeSpecialMenu(string province, string dishType, int specialMenu)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/province=" +province+ "&dishType=" +dishType+ 
                "&specialMenu=" +specialMenu;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncRegionDishType(string region, string dishType)
        {

            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/region=" +region+ "&dishType=" +dishType;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERRORE {0}", ex.Message);
            }


            return Restaurants;
        }

        public async Task<IEnumerable<RestaurantFromQuery>> GetRestaurantAsyncRegionDishTypeSpecialMenu(string region, string dishType, int specialMenu)
        {
            Restaurants = new List<RestaurantFromQuery>();

            string query = Constants.APIRestaurantsGet + "/region=" +region+ "&dishType=" +dishType+ 
                "&specialMenu=" +specialMenu;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Restaurants = JsonSerializer.Deserialize<List<RestaurantFromQuery>>(content, serializerOptions);
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
