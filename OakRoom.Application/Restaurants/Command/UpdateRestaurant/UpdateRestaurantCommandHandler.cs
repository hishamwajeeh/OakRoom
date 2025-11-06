using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OakRoom.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakRoom.Application.Restaurants.Command.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
        IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Update Restaurant for RestaurantId: {RestaurantId}", request.Id);
            var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
                return false;
            mapper.Map(request, restaurant);
            await restaurantRepository.SaveChanges();
            return true;
        }
    }
}
