
using Entity.Dtos.AddressDtos;

namespace Service.Abstracts
{
    public interface IAddressService
    {
        Task<AddressDto> GetAddressAsync(int id, bool trackChanges);
        Task<AddressDto> CreatedAddressAsync(AddressDto addressDto);
        Task DeleteAddress(int id, bool trackChanges);
        Task UpdateAddress(int id,AddressDto addressDto,bool trackChanges);
    }
}
