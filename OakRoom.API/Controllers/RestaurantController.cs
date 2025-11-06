using MediatR;
using Microsoft.AspNetCore.Mvc;
using OakRoom.Application.Restaurants.Command.CreateRestaurant;
using OakRoom.Application.Restaurants.Command.DeleteRestaurant;
using OakRoom.Application.Restaurants.Command.UpdateRestaurant;
using OakRoom.Application.Restaurants.Query.GetAllRestaurants;
using OakRoom.Application.Restaurants.Query.GetRestaurantById;

namespace OakRoom.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute] int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
        {
            var restaurantId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetRestaurantById), new { id = restaurantId }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] UpdateRestaurantCommand command)
        {
            command.Id = id;
            var isUpdated = await mediator.Send(command);
            if (isUpdated)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
