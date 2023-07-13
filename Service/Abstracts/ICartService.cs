
using Entity.Dtos.CartDtos;

namespace Service.Abstracts
{
    public interface ICartService
    {
        Task<CartDto> GetCartAsync(int id,bool trackChanges);
        Task AddProductToCart(int userId,int productId);
        Task RemoveProductToCart(int userId, int productId);
    }
}
