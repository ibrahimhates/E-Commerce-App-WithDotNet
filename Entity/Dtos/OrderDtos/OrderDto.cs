
using Entity.Dtos.AddressDtos;
using Entity.Dtos.ProdcutOrderDtos;
using Entity.Models;

namespace Entity.Dtos.OrderDtos
{
    public record OrderDto
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public DateTime OrderDate { get; init; }
        public decimal TotalAmount { get; init; }
        public bool PaymentStatus { get; init; }
        public bool DeliveryStatus { get; init; }
        public ICollection<ProductOrderDto> Products { get; init; }
    }
}
