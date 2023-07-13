using Entity.Dtos.ProductDtos;
using Entity.Models;
using Entity.RequestFeatures;

namespace Repository.Repositories.Abstracts
{
    public interface IProductRepository : IGenericRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAllProductAsync(
            ProductParams productParams,bool trackChanges);

        Task<IEnumerable<Product>> GetAllProductByCategory(
            ProductParams productParams,int id, bool trackChanges);
        Task<Product?> GetOneProductByIdAsync(int id, bool trackChanges);

        Task<int> GetCountWithAllMembers(ProductParams productParams);
    }
}
