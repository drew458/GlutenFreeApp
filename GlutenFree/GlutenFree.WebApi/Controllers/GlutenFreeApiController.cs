using GlutenFree.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlutenFree.WebApi.Controllers
{
    public class GlutenFreeApiController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class RestaurantController : ControllerBase
        {

            public static List<Restaurant> Restaurants { get; } = new List<Restaurant>();
            // GET: api/Restaurant
            [HttpGet]
            public IEnumerable<Restaurant> Get()
            {
                return Restaurants;
            }

            // GET api/Restaurant/5
            [HttpGet("{id}")]
            public Restaurant Get(int id)
            {
                return Restaurants.FirstOrDefault(r => r.Id == id);
            }

            // POST api/Restaurant
            [HttpPost]
            public void Post([FromBody] Restaurant value)
            {
                Restaurants.Add(value);
            }

            // PUT api/Restaurant/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] Restaurant value)
            {
                var Restaurant = Restaurants.FirstOrDefault(c => c.Id == id);
                if (Restaurant == null)
                    return;

                Restaurant = value;
            }

            // DELETE api/<RestaurantController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                var Restaurant = Restaurants.FirstOrDefault(c => c.Id == id);
                if (Restaurant == null)
                    return;

                Restaurants.Remove(Restaurant);
            }
        }
}
