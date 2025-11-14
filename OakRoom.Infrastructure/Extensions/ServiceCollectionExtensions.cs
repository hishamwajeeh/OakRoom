using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OakRoom.Core.Repositories;
using OakRoom.Infrastructure.Persistence;
using OakRoom.Infrastructure.Repositories;
using OakRoom.Infrastructure.Sedders;

namespace OakRoom.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            var connectionString = configuration.GetConnectionString("OakRoomDb");

            
            services.AddDbContext<OakRoomDbContext>(options =>
                options.UseSqlServer(connectionString)
                       .EnableSensitiveDataLogging());

            
            services.AddScoped<IRestaurantSedder, RestaurantSedder>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();

            return services;
        }
    }
}
