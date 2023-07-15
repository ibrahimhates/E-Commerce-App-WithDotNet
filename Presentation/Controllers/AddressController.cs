
using Entity.Dtos.AddressDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilter;
using Service;
using Service.Abstracts;

namespace Presentation.Controllers
{
    [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> GetAddress()
        {
            var userId = TokenHelper.GetUserIdFromToken(HttpContext.User);
            var address = await _addressService.GetAddressAsync(userId, false);

            return Ok(address);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] AddressInsertionDto addressIDto)
        {
            var userId = TokenHelper.GetUserIdFromToken(HttpContext.User);
            var addressDto =
                new AddressDto() { UserId = userId, AddressName = addressIDto.AddressName };
            var address = await _addressService.CreatedAddressAsync(addressDto);

            return StatusCode(201, address);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] AddressInsertionDto addressIDto)
        {
            var userId = TokenHelper.GetUserIdFromToken(HttpContext.User);
            var addressDto =
                new AddressDto() { UserId = userId, AddressName = addressIDto.AddressName };

            await _addressService.UpdateAddressAsync(addressDto, false);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress()
        {
            var userId = TokenHelper.GetUserIdFromToken(HttpContext.User);
            await _addressService.DeleteAddressAsync(userId,false);

            return NoContent();
        }

    }
}
