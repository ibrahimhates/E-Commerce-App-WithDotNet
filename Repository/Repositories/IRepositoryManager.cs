﻿
using Repository.Repositories.Abstracts;

namespace Repository.Repositories
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IAddressRepository AddressRepository { get; }
        IOrderRepository OrderRepository { get; }
        ICartRepository CartRepository { get; }
        IProductOrderRepository ProductOrderRepository { get; }
        IProductBasketRepository ProductBasketRepository { get; }
        Task SaveAsync();
        void Save();
    }
}
