
using Entity.Dtos.AddressDtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilter;
using Service.Abstracts;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/[controller]s")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService=addressService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAddress([FromRoute(Name = "id")]int id)
        {
            var address = await _addressService.GetAddressAsync(id,false);

            return Ok(address);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody]AddressDto addressDto)
        {
            var address = await _addressService.CreatedAddressAsync(addressDto);

            return StatusCode(201,address);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody]AddressDto addressDto)
        {
            await _addressService.UpdateAddressAsync(addressDto, false);
            
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAddress([FromRoute(Name = "id")]int id)
        {
            await _addressService.DeleteAddressAsync(id,false);

            return NoContent();
        }

    }
}
