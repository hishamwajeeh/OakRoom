using Microsoft.EntityFrameworkCore;
using OakRoom.Core.Entities;
using OakRoom.Core.Repositories;
using OakRoom.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakRoom.Infrastructure.Repositories
{
    public class RestaurantRepository(OakRoomDbContext roomDbContext) : IRestaurantRepository
    {
        public Task<int> Create(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await roomDbContext.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            var restaurant =  await roomDbContext.Restaurants
                .Include(d => d.Dishes)
                .FirstOrDefaultAsync(r => r.Id == id);
            return restaurant;
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
