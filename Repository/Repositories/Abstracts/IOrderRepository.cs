using Entity.Models;

namespace Repository.Repositories.Abstracts
{
    public interface IOrderRepository : IGenericRepositoryBase<Order>
    {
        Task<IEnumerable<Order>> GetAllOrderAsync(int id,bool trackChanges);
        Task<Order?> GetOneOrderAsync(int id, bool trackChanges);
    }
}
