using MediatR;
using OakRoom.Application.Dishes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakRoom.Application.Dishes.GetDishByIdForRestaurant
{
    public class GetDishByIdForRestaurantQuery(int restaurantId, int dishId) : IRequest<DishDto>
    {
        public int RestaurantId { get; } = restaurantId;
        public int DishId { get; } = dishId;
    }
}
