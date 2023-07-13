
namespace Entity.Dtos.ProductDtos
{
    public record ProductInsertionDto
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int CategoryId { get; init; }
    }
}
