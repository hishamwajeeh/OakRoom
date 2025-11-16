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

namespace OakRoom.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> logger,
    IRestaurantRepository restaurantsRepository,
    IDishesRepository dishesRepository) : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogWarning("Removing all dishes from restaurant: {RestaurantId}", request.RestaurantId);

            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            await dishesRepository.Delete(restaurant.Dishes);
        }
    }
}
