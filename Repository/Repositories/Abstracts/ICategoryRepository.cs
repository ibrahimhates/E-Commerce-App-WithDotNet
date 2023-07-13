using Entity.Models;

namespace Repository.Repositories.Abstracts
{
    public interface ICategoryRepository : IGenericRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync(bool trackChanges);

        Task<Category?> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task<Category?> GetOneCategoryByIdWithProductAsync(int id, bool trackChanges);
    }
}
