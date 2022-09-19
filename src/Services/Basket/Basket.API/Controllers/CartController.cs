using Basket.API.Models.Entities;
using Basket.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _basketRepository;

        public CartController(ICartRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var basket = await _basketRepository.GetCart(username);
            return Ok(basket);
        }

        [HttpPut]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            var newBasket = await _basketRepository.UpdateCart(basket);
            return Ok(newBasket);
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteBasket(string username)
        {
            await _basketRepository.DeleteCart(username);
            return Ok();
        }
    }
}
