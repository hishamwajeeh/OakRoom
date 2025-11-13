using MediatR;
using Microsoft.AspNetCore.Mvc;
using OakRoom.Application.Restaurants.Command.CreateRestaurant;
using OakRoom.Application.Restaurants.Command.DeleteRestaurant;
using OakRoom.Application.Restaurants.Command.UpdateRestaurant;
using OakRoom.Application.Restaurants.Dtos;
using OakRoom.Application.Restaurants.Query.GetAllRestaurants;
using OakRoom.Application.Restaurants.Query.GetRestaurantById;

namespace OakRoom.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAllRestaurants()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto?>> GetRestaurantById([FromRoute] int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
        {
            var restaurantId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetRestaurantById), new { id = restaurantId }, null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            await mediator.Send(new DeleteRestaurantCommand(id));
            
            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] UpdateRestaurantCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
            
            return NoContent();
        }
    }
}
