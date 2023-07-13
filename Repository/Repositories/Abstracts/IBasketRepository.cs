using Entity.Models;

namespace Repository.Repositories.Abstracts
{
    public interface IBasketRepository : IGenericRepositoryBase<Basket>
    {
        Task<Basket?> GetBasketAsync(int id,bool trackChanges);

    }
}
