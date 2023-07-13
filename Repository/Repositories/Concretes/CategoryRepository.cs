using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Abstracts;

namespace Repository.Repositories.Concretes
{
    public class CategoryRepository : GenericRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ETContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync(bool trackChanges)
        {
            var categorys = await GetAll(trackChanges)
                .ToListAsync();

            return categorys;
        }

        public async Task<Category?> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await GetByCondition(x => x.Id == id,trackChanges)
                .SingleOrDefaultAsync();

            return category;
        }

        public async Task<Category?> GetOneCategoryByIdWithProductAsync(int id, bool trackChanges)
        {
            var category = await GetByCondition(x => x.Id == id, trackChanges)
                .Include(x => x.Products)
                .SingleOrDefaultAsync();

            return category;
        }
    }
}
