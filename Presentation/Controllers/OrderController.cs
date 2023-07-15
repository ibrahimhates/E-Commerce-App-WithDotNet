
using Entity.Dtos.OrderDtos;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService=orderService;
        }

        [HttpGet("all/")]
        public async Task<ActionResult> GetAllOrder()
        {
            var userId = TokenHelper.GetUserIdFromToken(HttpContext.User);
            var orders = await _orderService.GetAllOrderAsync(userId, false);

            return Ok(orders);
        }

        [HttpGet("one/{id:int}/")]
        public async Task<IActionResult> GetOneOrderById([FromRoute(Name = "id")]int id)
        {
            var order = await _orderService.GetOneOrderByIdAsync(id, false);

            return Ok(order);
        }

        [HttpPost("create/")]
        public async Task<IActionResult> CreateOrder()
        {
            var userId = TokenHelper.GetUserIdFromToken(HttpContext.User);
            var order = await _orderService.CreateOrderAsync(userId);
            
            return StatusCode(201,order);
        }

        [HttpPut("update/")]
        public async Task<IActionResult> UpdateOrder([FromBody]OrderUpdateDto orderUpdateDto)
        {
            await _orderService.UpdateOrderAsync(orderUpdateDto,false);

            return NoContent();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteOrder([FromRoute(Name = "id")]int id)
        {
            await _orderService.DeleteOrderAsync(id, false);

            return NoContent();
        }
    }
}
