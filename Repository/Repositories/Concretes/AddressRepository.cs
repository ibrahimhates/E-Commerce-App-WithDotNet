using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Abstracts;

namespace Repository.Repositories.Concretes
{
    public class AddressRepository : GenericRepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(ETContext context) : base(context)
        {
        }

        public async Task<Address?> GetAddressAsync(int id, bool trackChanges) =>
            await GetByCondition(x => x.UserId == id, trackChanges)
            .SingleOrDefaultAsync();
    }
}
