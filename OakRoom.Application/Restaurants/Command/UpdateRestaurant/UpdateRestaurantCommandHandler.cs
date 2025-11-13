using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OakRoom.Core.Entities;
using OakRoom.Core.Exceptions;
using OakRoom.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakRoom.Application.Restaurants.Command.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
        IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Update Restaurant for RestaurantId: {RestaurantId} with {@UpdateREstaurant}", request.Id, request);
            var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            mapper.Map(request, restaurant);
            await restaurantRepository.SaveChanges();
        }
    }
}
