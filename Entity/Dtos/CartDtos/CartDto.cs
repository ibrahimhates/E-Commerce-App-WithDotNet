
using Entity.Dtos.ProdcutCartDtos;

namespace Entity.Dtos.CartDtos
{
    public record CartDto
    {
        public int UserId { get; init; }
        public decimal Total { get; init; }
        public ICollection<ProductCartDto> Products { get; init; }
    }
}
