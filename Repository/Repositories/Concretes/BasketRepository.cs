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
    public class BasketRepository : GenericRepositoryBase<Basket>, IBasketRepository
    {
        public BasketRepository(ETContext context) : base(context)
        {
        }

        public async Task<Basket?> GetBasketAsync(int id, bool trackChanges) =>
            await GetByCondition(x => x.UserId == id, trackChanges)
            .SingleOrDefaultAsync();
    }
}
