using Entity.Models;
using Entity.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Repository.Repositories.Abstracts;

namespace Repository.Repositories.Concretes
{
    public class ProductRepository : GenericRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ETContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync(
            ProductParams productParams, bool trackChanges)
        {
            var products = await
                GetAll(trackChanges)
                .Search(x => x.Name, productParams.SearchTerm)
                .Sort(productParams.OrderBy)
                .ToPageList(productParams.PageNumber,productParams.PageSize)
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetAllProductByCategory(
            ProductParams productParams,int id, bool trackChanges)
        {
            var products = await
                GetByCondition(x => x.CategoryId == id,trackChanges)
                .Search(x => x.Name, productParams.SearchTerm)
                .Sort(productParams.OrderBy)
                .ToPageList(productParams.PageNumber, productParams.PageSize)
                .ToListAsync();

            return products;
        }

        public async Task<int> GetCountWithAllMembers(ProductParams productParams)
        {
            var count = await
                GetAll(false)
                .Search(x => x.Name, productParams.SearchTerm)
                .Sort(productParams.OrderBy)
                .CountAsync();

            return count;
        }

        public async Task<Product?> GetOneProductByIdAsync(int id, bool trackChanges)
        {
            var product = await 
                GetByCondition(x => x.Id == id,trackChanges)
                .SingleOrDefaultAsync();

            return product;
        }
    }
}
