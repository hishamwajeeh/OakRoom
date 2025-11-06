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
        public async Task<int> Create(Restaurant entity)
        {
            roomDbContext.Restaurants.Add(entity);
            await roomDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public Task Delete(Restaurant entity)
        {
            roomDbContext.Restaurants.Remove(entity);
            return roomDbContext.SaveChangesAsync();
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
            => roomDbContext.SaveChangesAsync();
    }
}
