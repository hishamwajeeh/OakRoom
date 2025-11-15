using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OakRoom.Application.Dishes.Commands.CreateDish;
using OakRoom.Application.Dishes.Dtos;
using OakRoom.Application.Dishes.GetDishByIdForRestaurant;
using OakRoom.Application.Dishes.GetDishesForRestaurant;

namespace OakRoom.API.Controllers
{
    [Route("api/restaurant/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            await mediator.Send(command);
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllDishes([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetDishById([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
            return Ok(dish);
        }
    }
}
