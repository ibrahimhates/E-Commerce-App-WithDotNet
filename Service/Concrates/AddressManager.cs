
using AutoMapper;
using Entity.Dtos.AddressDtos;
using Entity.Dtos.CategoryDtos;
using Entity.Exceptions.Address;
using Entity.Exceptions.Category;
using Entity.Models;
using Repository.Repositories;
using Service.Abstracts;
using Service.Abstracts.LoggerAbstract;

namespace Service.Concrates
{
    public class AddressManager : IAddressService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public AddressManager(
            IRepositoryManager repository, 
            ILoggerService logger, 
            IMapper mapper)
        {
            _repository=repository;
            _logger=logger;
            _mapper=mapper;
        }

        public async Task<AddressDto> GetAddressAsync(int id, bool trackChanges)
        {
            var address = await GetAddressCheckExistAsync(id ,trackChanges);

            var addressDto = _mapper.Map<AddressDto>(address);

            _logger.LogInfo($"Address returned successfully with id: {id}");

            return addressDto;

        }
        public async Task<AddressDto> CreatedAddressAsync(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            var exist = await _repository
                .AddressRepository
                .AnyAsync(x => x.UserId == addressDto.UserId);

            if(exist)
            {
                _logger.LogInfo($"Address already exists with userId:{address.UserId}");
                throw new AddressBadRequestException(address.UserId);
            }

            await _repository
                .AddressRepository
                .CreateAsync(address);

            await _repository.SaveAsync();

            _logger.LogInfo($"Category created {address.UserId}");

            return _mapper.Map<AddressDto>(address);
        }
        public async Task UpdateAddressAsync(AddressDto addressDto, bool trackChanges)
        {
            var address = await GetAddressCheckExistAsync(addressDto.UserId, trackChanges);

            address = _mapper.Map(addressDto, address);
            _repository.AddressRepository.Update(address);
            await _repository.SaveAsync();

            _logger.LogInfo($"Address updated with userid: {addressDto.UserId}");
        }
        public async Task DeleteAddressAsync(int id, bool trackChanges)
        {
            var address = await GetAddressCheckExistAsync(id, trackChanges);

            _repository.AddressRepository.Delete(address);
            await _repository.SaveAsync();

            _logger.LogInfo($"Address deleted with userid: {id}");
        }
        private async Task<Address> GetAddressCheckExistAsync(int id,bool trackChanges)
        {
            var address = await _repository
                .AddressRepository
                .GetAddressAsync(id, trackChanges);
            
            if(address is null)
            {
                _logger.LogWarning($"Category could not found with id: {id}");
                throw new AddressNotFoundException(id);
            }

            return address;
        }

    }
}
