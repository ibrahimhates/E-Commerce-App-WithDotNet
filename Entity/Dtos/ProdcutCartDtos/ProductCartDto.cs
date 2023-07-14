
using Entity.Dtos.CartDtos;
using Entity.Dtos.ProductDtos;

namespace Entity.Dtos.ProdcutCartDtos
{
    public record ProductCartDto
    {
        public int ProductId { get; init; }
        public int BasketId { get; init; }
        public ProductDto Product { get; init; }
        public CartDto Basket { get; init; }
    }
}
