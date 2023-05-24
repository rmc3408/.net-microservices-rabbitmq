using basket.API.BusinessServices;
using basket.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace basket.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketServices _backetServiceRepo;

        public BasketController(IBasketServices basket)
        {
            _backetServiceRepo = basket;
        }

        // GET: /{username}
        [HttpGet("{name}", Name="get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cart))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cart>> Get(string name)
        {
            var basket = await _backetServiceRepo.GetBasket(name);
            return basket == null ? NotFound(new Cart(name)) : Ok(basket);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Cart))]
        public async Task<ActionResult<Cart>> Post([FromBody] Cart cart)
        {
            var updatedBasket = await _backetServiceRepo.UpdateBasket(cart);
            return Ok(updatedBasket);
        }

        [HttpDelete("{name}", Name = "delete")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(void))]
        public async Task<ActionResult> Delete(string name)
        {
            await _backetServiceRepo.DeleteBasket(name);
            return Ok();
        }
    }
}