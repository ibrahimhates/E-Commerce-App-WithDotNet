using Entity.Dtos.ProductDtos;
using Entity.RequestFeatures;

namespace Service.Abstracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductDto> productDtos,MetaData metaData)> GetAllProductsAsync(
            ProductParams productParams,bool trackChanges);
        Task<(IEnumerable<ProductDto> productDtos, MetaData metaData)> GetAllProductByCategoryId(
            ProductParams productParams,int id,bool trackChanges);
        Task<ProductDto?> GetOneProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto?> CreateOneProductAsync(ProductInsertionDto productInsertionDto);
        Task UpdateOneProductAsync(ProductUpdateDto productUpdateDto, bool trackChanges);
        Task DeleteOneProductAsync(int id, bool trackChanges);
    }
}
