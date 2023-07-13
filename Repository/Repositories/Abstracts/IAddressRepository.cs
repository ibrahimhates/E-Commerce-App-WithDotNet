using Entity.Models;

namespace Repository.Repositories.Abstracts
{
    public interface IAddressRepository : IGenericRepositoryBase<Address>
    {
        Task<Address?> GetAddressAsync(int id,bool trackChanges);
    }
}
    