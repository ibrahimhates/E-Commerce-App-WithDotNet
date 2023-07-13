
using Entity.Models;

namespace Entity.Dtos.CartDtos
{
    public record CartDto
    {
        public int UserId { get; init; }
        public decimal Total { get; init; }
        public ICollection<ProductCart> Products { get; init; }
    }
}
