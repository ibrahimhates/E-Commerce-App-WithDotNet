
using Entity.Dtos.AddressDtos;

namespace Service.Abstracts
{
    public interface IAddressService
    {
        Task<AddressDto> GetAddressAsync(int id, bool trackChanges);
        Task<AddressDto> CreatedAddressAsync(AddressDto addressDto);
        Task DeleteAddressAsync(int id, bool trackChanges);
        Task UpdateAddressAsync(AddressDto addressDto,bool trackChanges);
    }
}
