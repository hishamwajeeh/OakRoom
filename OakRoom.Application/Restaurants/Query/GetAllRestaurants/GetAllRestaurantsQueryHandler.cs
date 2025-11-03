using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OakRoom.Application.Restaurants.Dtos;
using OakRoom.Core.Repositories;

namespace OakRoom.Application.Restaurants.Query.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get All Restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();
            return mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        }
    }
}
