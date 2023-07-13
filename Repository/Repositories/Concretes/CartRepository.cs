using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Concretes
{
    public class CartRepository : GenericRepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(ETContext context) : base(context)
        {
        }

        public async Task<Cart?> GetCartAsync(int id, bool trackChanges) =>
            await GetByCondition(x => x.UserId == id, trackChanges)
            .Include(x => x.Products)
                .ThenInclude(x => x.Product)
            .SingleOrDefaultAsync();
    }
}
