using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Abstracts;

namespace Repository.Repositories.Concretes
{
    public class OrderRepository : GenericRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ETContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync(int id,bool trackChanges)
        {
            var orders = await 
                GetByCondition(x => x.UserId == id,trackChanges)
                .ToListAsync();

            return orders;
        }

        public async Task<Order?> GetOneOrderAsync(int id, bool trackChanges) => 
            await GetByCondition(x => x.Id == id,trackChanges)
            .SingleOrDefaultAsync();

    }
}
