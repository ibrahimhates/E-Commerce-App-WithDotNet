using Entity.Dtos.OrderDtos;
using Entity.Dtos.ProductDtos;

namespace Entity.Dtos.ProdcutOrderDtos
{
    public record ProductOrderDto
    {
        public int ProductId { get; init; }
        public int OrderId { get; init; }
        public ProductDto Product { get; init; }
        public OrderDto Order { get; init; }
    }

}
