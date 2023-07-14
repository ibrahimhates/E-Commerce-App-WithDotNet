using AutoMapper;
using Entity.Dtos.CategoryDtos;
using Entity.Exceptions.Category;
using Entity.Models;
using Repository.Repositories;
using Service.Abstracts;
using Service.Abstracts.LoggerAbstract;

namespace Service.Concrates
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public CategoryManager(
            IRepositoryManager repository, 
            ILoggerService logger, 
            IMapper mapper)
        {
            _repository=repository;
            _logger=logger;
            _mapper=mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categorys = await _repository
                .CategoryRepository
                .GetAllCategoryAsync(trackChanges);

            var categoryDtos = _mapper.Map<List<CategoryDto>>(categorys);

            var count = categoryDtos.Count();
            _logger.LogInfo($"All category returned successfully {count}");
            
            return categoryDtos;
        }

        public async Task<CategoryDetailDto> GetOneCategoryByIdWithProductAsync(int id, bool trackChanges)
        {
            var category = await _repository
                .CategoryRepository
                .GetOneCategoryByIdWithProductAsync(id, trackChanges);

            if(category is null)
            {
                _logger.LogWarning($"Category could not found with id: {id}");
                throw new CategoryNotFoundException(id);
            }

            return _mapper.Map<CategoryDetailDto>(category);
        }

        public async Task<CategoryDto> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await GetOneCategoryByIdCheckExistAsync(id, trackChanges);

            var categoryDto = _mapper.Map<CategoryDto>(category);
            _logger.LogInfo($"One category returned successfully with id: {id}");

            return categoryDto;
        }

        public async Task<CategoryDto> CreateOneCategoryAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            await _repository
                .CategoryRepository
                .CreateAsync(category);
            await _repository.SaveAsync();

            _logger.LogInfo("Category created");

            return categoryDto;
        }

        public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
        {
            var category = await GetOneCategoryByIdCheckExistAsync(id, trackChanges);

            _repository.CategoryRepository.Delete(category);
            _logger.LogInfo($"Category deleted {category.Id}");

            await _repository.SaveAsync();
        }

        public async Task UpdateOneCategoryAsync(int id, CategoryDto categoryDto, bool trackChanges)
        {
            var category = await GetOneCategoryByIdCheckExistAsync(id, trackChanges);

            category = _mapper.Map(categoryDto, category);
            _repository.CategoryRepository.Update(category);

            _logger.LogInfo($"Category updated with id: {id}");

            await _repository.SaveAsync();
        }

        private async Task<Category> GetOneCategoryByIdCheckExistAsync(int id, bool trackChanges)
        {
            var category = await _repository
                .CategoryRepository
                .GetOneCategoryByIdAsync(id, trackChanges);

            if (category is null)
            {
                _logger.LogWarning($"Category could not found with id: {id}");
                throw new CategoryNotFoundException(id);
            }

            return category;
        }
    }
}
