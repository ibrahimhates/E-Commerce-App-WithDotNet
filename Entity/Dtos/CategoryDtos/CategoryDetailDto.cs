using Entity.Dtos.ProductDtos;

namespace Entity.Dtos.CategoryDtos
{
    public record CategoryDetailDto : CategoryDto
    {
        public ICollection<ProductDto> Products { get; init; }
    }
}
