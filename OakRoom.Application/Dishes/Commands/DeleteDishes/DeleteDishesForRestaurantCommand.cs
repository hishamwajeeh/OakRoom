using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakRoom.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommand(int restaurantId) : IRequest
    {
        public int RestaurantId { get; } = restaurantId;
    }
}
