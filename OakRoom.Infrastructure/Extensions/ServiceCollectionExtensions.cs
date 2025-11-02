using Microsoft.Extensions.DependencyInjection;
using OakRoom.Core.Repositories;
using OakRoom.Infrastructure.Repositories;
using OakRoom.Infrastructure.Sedders;

namespace OakRoom.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Infrastructure service registrations go here
            services.AddScoped<IRestaurantSedder, RestaurantSedder>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            return services;
        }
    }
}
