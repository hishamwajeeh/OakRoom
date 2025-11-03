using MediatR;
using OakRoom.Application.Restaurants.Dtos;
using System.Collections.Generic;

namespace OakRoom.Application.Restaurants.Query.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto?>>
    {
    }
}
