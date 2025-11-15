using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OakRoom.Application.Dishes.Dtos;
using OakRoom.Core.Entities;
using OakRoom.Core.Exceptions;
using OakRoom.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakRoom.Application.Dishes.GetDishesForRestaurant
{
    public class GetDishesForRestaurantQueryHandler(ILogger<GetDishesForRestaurantQueryHandler> logger,
    IRestaurantRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving dishes for restaurant with id: {RestaurantId}", request.RestaurantId);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            var results = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

            return results;
        }
    }
}
