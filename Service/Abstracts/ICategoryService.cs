
using Entity.Dtos.CategoryDtos;
using Entity.Models;

namespace Service.Abstracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
        Task<CategoryDto> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task<CategoryDetailDto> GetOneCategoryByIdWithProductAsync(int id, bool trackChanges);
        Task<CategoryDto> CreateOneCategoryAsync(CategoryDto categoryDto);
        Task UpdateOneCategoryAsync(int id, CategoryDto categoryDto, bool trackChanges);
        Task DeleteOneCategoryAsync(int id, bool trackChanges);
    }
}
