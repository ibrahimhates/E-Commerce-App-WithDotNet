using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilter;
using Service;
using Service.Abstracts;

namespace Presentation.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetCart()
        {
            var userId = TokenHelper.GetUserIdFromToken(HttpContext.User);
            var cart = await _cartService.GetCartAsync(userId, false);

            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCart([FromQuery] int productId)
        {
            var userId = TokenHelper.GetUserIdFromToken(HttpContext.User);
            await _cartService.AddProductToCart(userId, productId);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProductToCart([FromQuery] int productId)
        {
            var userId = TokenHelper.GetUserIdFromToken(HttpContext.User);
            await _cartService.RemoveProductToCart(userId, productId);

            return NoContent();
        }
    }
}
