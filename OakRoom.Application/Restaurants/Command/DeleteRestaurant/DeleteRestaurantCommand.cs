using MediatR;

namespace OakRoom.Application.Restaurants.Command.DeleteRestaurant
{
    public class DeleteRestaurantCommand(int id) : IRequest
    {
        public int Id { get; } = id;
    }
}
