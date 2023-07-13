
using Entity.Models;

namespace Entity.Dtos.BasketDtos
{
    public record BasketDto
    {
        public int UserId { get; init; }
        public decimal Total { get; init; }
        public ICollection<ProductBasket> Products { get; init; }
    }
}
