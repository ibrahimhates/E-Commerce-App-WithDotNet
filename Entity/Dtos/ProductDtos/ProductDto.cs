using Entity.Models;

namespace Entity.Dtos.ProductDtos
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public bool StockStatus { get; init; }
        public DateTime CreatedDate { get; init; }
        public int CategoryId { get; init; }
        public Category Category { get; init; }
    }
}
