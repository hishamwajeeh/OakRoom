using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OakRoom.Core.Entities;
using OakRoom.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakRoom.Application.Restaurants.Command.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger,
        IMapper mapper, IRestaurantRepository restaurantRepository)
        : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new restaurant with name: {@RestaurantName}", request);

            var restaurant = mapper.Map<Restaurant>(request);

            int id = await restaurantRepository.Create(restaurant);
            return id;
        }
    }
}
