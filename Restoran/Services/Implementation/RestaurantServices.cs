using Restoran.Models;

namespace Restoran.Services.Implementation
{
    public class RestaurantServices : IRestorauntServices
    {
        public List<Restaurant> GetRestaurants()
        {
            return new List<Restaurant> {
            new Restaurant(){Id=0,Name="Красти Крабс", Address="Бикини Ботом" }
            };
        }
    }
}
