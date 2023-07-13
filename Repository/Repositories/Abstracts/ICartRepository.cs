using Entity.Models;

namespace Repository.Repositories.Abstracts
{
    public interface ICartRepository : IGenericRepositoryBase<Cart>
    {
        Task<Cart?> GetCartAsync(int id,bool trackChanges);

    }
}
