using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilter;
using Service.Abstracts;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/[controller]s")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService=cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart(int id)
        {
            var cart = await _cartService.GetCartAsync(id, false);

            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCart([FromQuery] int id,
            [FromQuery] int productId)
        {
            await _cartService.AddProductToCart(id, productId);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProductToCart([FromQuery] int id,
            [FromQuery] int productId)
        {
            await _cartService.RemoveProductToCart(id, productId);

            return NoContent();
        }
    }
}
