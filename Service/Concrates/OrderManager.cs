using AutoMapper;
using Entity.Dtos.OrderDtos;
using Entity.Exceptions.Cart;
using Entity.Exceptions.Order;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Service.Abstracts;
using Service.Abstracts.LoggerAbstract;

namespace Service.Concrates
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        public OrderManager(
            IRepositoryManager repository,
            IMapper mapper,
            ILoggerService logger)
        {
            _repository=repository;
            _mapper=mapper;
            _logger=logger;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrderAsync(int userId, bool trackChanges)
        {
            var orders = await _repository
                .OrderRepository
                .GetAllOrderAsync(userId, trackChanges);

            var orderDtos = _mapper.Map<List<OrderDto>>(orders);

            _logger.LogInfo($"All orders returned successfull with userId:{userId}");

            return orderDtos;
        }
        public async Task<OrderDto> GetOneOrderByIdAsync(int userId, int orderId, bool trackChanges)
        {
            var order = await GetOneOrderCheckExistAsync(userId,orderId, trackChanges);

            var orderDto = _mapper.Map<OrderDto>(order);

            _logger.LogInfo($"One Order returned successfully with id:{orderId}");

            return orderDto;
        }
        public async Task<OrderDto> CreateOrderAsync(int userId)
        {
            var cart = await _repository
                .CartRepository
                .GetCartAsync(userId, false);
            
            if(cart is null)
            {
                _logger.LogWarning("Cart could not found while create Order with userId:{userId}");
                throw new CartNotFoundException();
            }

            var orderDate = DateTime.Now;
            var order = new Order()
            {
                DeliveryStatus = false,
                PaymentStatus = false,
                TotalAmount = cart.Total,
                OrderDate = orderDate,
                UserId = userId
            };

            await _repository.OrderRepository.CreateAsync(order);
            _repository.CartRepository.Delete(cart);

            await _repository.SaveAsync();

            var orderId = await _repository
                .OrderRepository
                .GetByCondition(x => x.OrderDate == orderDate, false)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            await _repository
                .ProductOrderRepository
                .CreateRangeAsync(CreateProductofOrder(cart, orderId));

            await _repository.SaveAsync();

            var createdOrder = await _repository
                .OrderRepository
                .GetOneOrderAsync(userId, orderId,false);

            _logger.LogInfo($"Created new Order and deleted cart with userId:{userId}");

            return _mapper.Map<OrderDto>(createdOrder);
        }
        public async Task UpdateOrderAsync(int userId,OrderUpdateDto orderUpdateDto, bool trackChanges)
        {
            var order = await GetOneOrderCheckExistAsync(userId,orderUpdateDto.Id, trackChanges);

            order = _mapper.Map(orderUpdateDto, order);

            _repository.OrderRepository.Update(order);
            await _repository.SaveAsync();
            
            _logger.LogInfo($"Updated order: id : {orderUpdateDto.Id}");
        }
        public async Task DeleteOrderAsync(int userId,int id, bool trackChanges)
        {
            var order = await GetOneOrderCheckExistAsync(userId, id, trackChanges);

            _repository.OrderRepository.Delete(order);
            await _repository.SaveAsync();

            _logger.LogInfo($"Deleted Order with id:{order.Id}");
        }

        private async Task<Order> GetOneOrderCheckExistAsync(int userId, int orderId, bool trackChanges)
        {
            var order = await _repository
                .OrderRepository
                .GetOneOrderAsync(userId,orderId, trackChanges);

            if(order is null)
            {
                _logger.LogWarning($"Order could not found with id: {orderId}");
                throw new OrderNotFoundException(orderId);
            }

            return order;
        } 
        private List<ProductOrder> CreateProductofOrder(Cart cart,int orderId)
        {
            var productOrders = new List<ProductOrder>();
            foreach (var product in cart.Products)
            {
                productOrders.Add(new ProductOrder()
                {
                    OrderId = orderId,
                    ProductId = product.ProductId,
                });
            }

            return productOrders;
        }
    }
}
