﻿
using AutoMapper;
using Entity.Dtos.CartDtos;
using Entity.Exceptions.Cart;
using Entity.Exceptions.Product;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.Repositories.Abstracts;
using Service.Abstracts;
using Service.Abstracts.LoggerAbstract;
using System.Linq.Expressions;

namespace Service.Concrates
{
    public class CartManager : ICartService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public CartManager(
            IRepositoryManager repository,
            ILoggerService logger,
            IMapper mapper)
        {
            _repository=repository;
            _logger=logger;
            _mapper=mapper;
        }

        public async Task<CartDto> GetCartAsync(int id, bool trackChanges)
        {
            var cart = await _repository.CartRepository.GetCartAsync(id, trackChanges);
            if (cart is null)
            {
                _logger.LogWarning($"Cart could not found maybe is empty userId:{id}");
                throw new CartNotFoundException();
            }

            return _mapper.Map<CartDto>(cart);
        }

        public async Task AddProductToCart(int userId, int productId)
        {
            var isExist = await _repository
                .CartRepository
                .AnyAsync(x => x.UserId == userId);

            var cart = new Cart()
            {
                UserId = userId,
                Total = 0,
            };
            
            if (!isExist)
            {
                await _repository.CartRepository.CreateAsync(cart);
                await _repository.SaveAsync();

                _logger.LogInfo($"Cart created with userId:{userId}");
            }

            var productCart = new ProductCart()
            {
                BasketId = userId,
                ProductId = productId
            };

            var price = await _repository
                .ProductRepository
                .GetByCondition(p => p.Id == productId, false)
                .Select(p => p.Price)
                .FirstOrDefaultAsync();

            cart = await _repository
                .CartRepository
                .GetCartAsync(userId, true);

            if (cart.Products.Any(x => x.ProductId == productId && x.BasketId == userId))
            {
                _logger.LogWarning($"The Product already exist in cart id:{userId}");
                throw new CartBadRequestException(userId);
            }

            await _repository
                .ProductBasketRepository
                .CreateAsync(productCart);

            cart.Total += price;
            _repository.CartRepository.Update(cart);

            await _repository.SaveAsync();

            _logger.LogInfo($"The product added in cart");
        }

        public async Task RemoveProductToCart(int userId, int productId)
        {
            var cart = await _repository
                .CartRepository
                .GetCartAsync(userId, false);

            if (cart is null)
            {
                _logger.LogWarning($"Cart could not found with userId:{userId}");
                throw new CartNotFoundException();
            }

            var productInCart = cart.Products
                .Where(p => p.ProductId == productId)
                .FirstOrDefault();

            if (productInCart is null )
            {
                _logger.LogWarning($"The product not found in cart with id:{userId}");
                throw new ProductNotFoundException(productId);
            }

            var price = await _repository
                .ProductRepository
                .GetByCondition(x => x.Id == productId,false)
                .Select(p => p.Price)
                .FirstOrDefaultAsync();

            cart.Total -= price;
            var result  = cart.Products.Remove(productInCart);

            if (cart.Products.Count == 0)
                _repository.CartRepository.Delete(cart);
            else
                _repository.CartRepository.Update(cart);

            _repository.ProductBasketRepository.Delete(productInCart);

            await _repository.SaveAsync();

        }
    }
}
