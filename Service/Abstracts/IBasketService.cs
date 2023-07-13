
using Entity.Dtos.BasketDtos;

namespace Service.Abstracts
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketAsync(int id,bool trackChanges);
        Task AddProductToBasket(int userId,int productId);
        Task RemoveProductToBasket(int userId, int productId);
    }
}
