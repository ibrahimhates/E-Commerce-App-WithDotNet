
using Entity.Dtos.OrderDtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilter;
using Service.Abstracts;

namespace Presentation.Controllers
{
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

        [HttpGet("all/{id:int}/")]
        public async Task<ActionResult> GetAllOrder([FromRoute(Name = "id")]int id)
        {
            var orders = await _orderService.GetAllOrderAsync(id, false);

            return Ok(orders);
        }

        [HttpGet("one/{id:int}/")]
        public async Task<IActionResult> GetOneOrderById([FromRoute(Name = "id")]int id)
        {
            var order = await _orderService.GetOneOrderByIdAsync(id, false);

            return Ok(order);
        }

        [HttpPost("create/{id:int}")]
        public async Task<IActionResult> CreateOrder([FromRoute(Name = "id")]int id)
        {
            var order = await _orderService.CreateOrderAsync(id);
            
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
