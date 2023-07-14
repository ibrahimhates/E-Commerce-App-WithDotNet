
using Entity.Dtos.OrderDtos;

namespace Service.Abstracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrderAsync(int userId,bool trackChanges);
        Task<OrderDto> GetOneOrderByIdAsync(int orderId, bool trackChanges);
        Task<OrderDto> CreateOrderAsync(int userId);
        Task UpdateOrderAsync(int id, OrderUpdateDto orderUpdateDto, bool trackChanges);
        Task DeleteOrderAsync(int id,bool trackChanges);
    }
}
