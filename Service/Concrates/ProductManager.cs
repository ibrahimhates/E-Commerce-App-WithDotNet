using AutoMapper;
using Entity.Dtos.ProductDtos;
using Entity.Exceptions.Product;
using Entity.Models;
using Entity.RequestFeatures;
using Repository.Repositories;
using Service.Abstracts;
using Service.Abstracts.LoggerAbstract;

namespace Service.Concrates
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public ProductManager(
            IRepositoryManager repository,
            ILoggerService logger,
            IMapper mapper)
        {
            _repository=repository;
            _logger=logger;
            _mapper=mapper;
        }

        public async Task<(IEnumerable<ProductDto> productDtos, MetaData metaData)> GetAllProductsAsync
            (ProductParams productParams, bool trackChanges)
        {
            var products = await _repository
                .ProductRepository
                .GetAllProductAsync(productParams, trackChanges);

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            var metaData = await 
                GetMetaDataAndSetLoggerAsync("All products returned successfully",
                productParams);

            return (products: productDtos, metaData: metaData);
        }

        public async Task<(IEnumerable<ProductDto> productDtos, MetaData metaData)> GetAllProductByCategoryId
            (ProductParams productParams, int id, bool trackChanges)
        {
            var products = await _repository
                .ProductRepository
                .GetAllProductAsync(productParams, trackChanges);

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            var metaData = await
                GetMetaDataAndSetLoggerAsync("All products returned" +
                $" by categoryId:{id} successfully",
                productParams);

            return (products: productDtos, metaData: metaData);
        }

        public async Task<ProductDto?> GetOneProductByIdAsync(int id, bool trackChanges)
        {
            var product = await GetOneProductCheckExistAsync(id, trackChanges);

            var productDto = _mapper.Map<ProductDto>(product);
            
            _logger.LogInfo($"One Product returned successfully with id: {id}");

            return productDto;
        }

        public async Task<ProductDto?> CreateOneProductAsync(ProductInsertionDto productInsertionDto)
        {
            var product = _mapper.Map<Product>(productInsertionDto);
            product.CreatedDate = DateTime.Now;

            var result = await  _repository
                .CategoryRepository
                .AnyAsync(x => x.Id == product.CategoryId);

            if (!result)
                throw new ProductBadRequestException(product.CategoryId);

            await _repository.ProductRepository.CreateAsync(product);
            await _repository.SaveAsync();

            _logger.LogInfo($"Product created");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateOneProductAsync(int id, ProductUpdateDto productUpdateDto, bool trackChanges)
        {
            var product = await GetOneProductCheckExistAsync(id, trackChanges);

            product = _mapper.Map(productUpdateDto, product);
            _repository.ProductRepository.Update(product);

            _logger.LogInfo($"Product updated with id: {id}");

            await _repository.SaveAsync();
        }

        public async Task DeleteOneProductAsync(int id, bool trackChanges)
        {
            var product = await GetOneProductCheckExistAsync(id, trackChanges);

            _repository.ProductRepository.Delete(product);

            _logger.LogInfo($"Product deleted with id: {id}");

            await _repository.SaveAsync();
        }
        private async Task<MetaData> GetMetaDataAndSetLoggerAsync(
            string message,ProductParams productParams)
        {
            var count = await _repository
                .ProductRepository
                .GetCountWithAllMembers(productParams);

            var metaData = new MetaData()
            {
                CurrentPage = productParams.PageNumber,
                PageSize = productParams.PageSize,
                TotalPage = (int)Math.Ceiling(count/(double)productParams.PageSize),
                TotalCount = count
            };

            _logger.LogInfo($"{message}. " +
                $"Product Count:{count}, Number on a page:{productParams.PageSize}");

            return metaData;
        }

        private async Task<Product> GetOneProductCheckExistAsync(int id,bool trackChanges)
        {
            var product = await _repository
                .ProductRepository
                .GetOneProductByIdAsync(id, trackChanges);

            if (product is null)
            {
                _logger.LogWarning($"Product could not found with id: {id}");
                throw new ProductNotFoundException(id);
            }

            return product;
        }

    }
}
