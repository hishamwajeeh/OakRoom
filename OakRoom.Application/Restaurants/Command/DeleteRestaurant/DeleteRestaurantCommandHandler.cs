using MediatR;
using Microsoft.Extensions.Logging;
using OakRoom.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakRoom.Application.Restaurants.Command.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Delete Restaurant for Id: {Id}", request.Id);
            var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
                return false;
            await restaurantRepository.Delete(restaurant);
            return true;
        }
    }
}
