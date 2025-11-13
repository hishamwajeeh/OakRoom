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

namespace OakRoom.Application.Restaurants.Command.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Delete Restaurant for Id: {Id}", request.Id);
            var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            await restaurantRepository.Delete(restaurant);
        }
    }
}
