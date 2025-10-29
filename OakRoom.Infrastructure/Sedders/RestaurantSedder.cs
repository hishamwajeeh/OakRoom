using OakRoom.Core.Entities;
using OakRoom.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakRoom.Infrastructure.Sedders
{
    public class RestaurantSedder(OakRoomDbContext dbContext) : IRestaurantSedder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    await dbContext.Restaurants.AddRangeAsync(restaurants);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {


            List<Restaurant> restaurants = [
                new()
            {
                Name = "Ezz El-Munufi",
                Category = "Fast Food",
                Description = "Ezz El-Munufi is an Egyptian restaurant for Sandwiche's.",
                ContactEmail = "contact@ezz.com",
                HasDelivery = true,
                Dishes =
                [
                    new ()
                    {
                        Name = "Kebda",
                        Description = "kebda sandwich",
                        Price = 10.30M,
                    },

                    new ()
                    {
                        Name = "Kofta",
                        Description = "Kofta Sandwich",
                        Price = 5.30M,
                    },
                ],
                Address = new ()
                {
                    City = "Giza",
                    Street = "Dukki",
                    PostalCode = "GD123"
                },

            },
            new ()
            {
                Name = "El-Barka",
                Category = "Fast Food",
                Description = "El-Barka is an egyptian restaurant for fast food.",
                ContactEmail = "contact@elbarka.com",
                HasDelivery = true,
                Address = new Address()
                {
                    City = "Alex",
                    Street = "Smouha",
                    PostalCode = "AS123"
                }
            }
            ];

            return restaurants;
        }
    }
}
