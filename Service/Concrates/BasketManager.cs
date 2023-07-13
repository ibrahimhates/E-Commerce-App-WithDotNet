
using AutoMapper;
using Entity.Dtos.BasketDtos;
using Entity.Exceptions.Cart;
using Entity.Models;
using Repository.Repositories;
using Repository.Repositories.Abstracts;
using Service.Abstracts;
using Service.Abstracts.LoggerAbstract;
using System.Linq.Expressions;

namespace Service.Concrates
{
    public class BasketManager : IBasketService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public BasketManager(
            IRepositoryManager repository, 
            ILoggerService logger, 
            IMapper mapper)
        {
            _repository=repository;
            _logger=logger;
            _mapper=mapper;
        }

        public async Task<BasketDto> GetBasketAsync(int id, bool trackChanges)
        {
            var cart = await _repository.BasketRepository.GetBasketAsync(id, trackChanges);
            if (cart is null) 
            {
                _logger.LogWarning($"Cart could not found maybe is empty userId:{id}");
                throw new CartNotFoundException();
            }

            return _mapper.Map<BasketDto>(cart);
        }
        public Task AddProductToBasket(int userId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductToBasket(int userId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
