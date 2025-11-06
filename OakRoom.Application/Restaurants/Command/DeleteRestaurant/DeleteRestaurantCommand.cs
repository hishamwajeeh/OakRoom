using MediatR;

namespace OakRoom.Application.Restaurants.Command.DeleteRestaurant
{
    public class DeleteRestaurantCommand(int id) : IRequest<bool>
    {
        public int Id { get; } = id;
    }
}
