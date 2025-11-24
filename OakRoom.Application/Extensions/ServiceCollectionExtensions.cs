using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Users;

namespace OakRoom.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);

            services.AddScoped<IUserContext, UserContext>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
