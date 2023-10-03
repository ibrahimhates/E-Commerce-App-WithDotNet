 
using Entity.Dtos.AuthDtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilter;
using Service.Abstracts.Auth;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/[controller]s")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService=authenticationService;
        }

        [HttpPost("register/")]
        public async Task<IActionResult> Register(
            [FromBody]UserForRegistrationDto userForRegistrationDto)
        {
            var result =  await _authenticationService.RegisterUserAsync(userForRegistrationDto);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            var userForAuthDto = new UserForAuthenticationDto()
            {
                UserName = userForRegistrationDto.UserName,
                Password = userForRegistrationDto.Password,
            };

            if (!await _authenticationService.ValidateUserAsync(userForAuthDto))
                return Unauthorized();

            var token = await _authenticationService
                .CreateTokenAsync();

            return Ok(token);
        }

        [HttpPost("login/")]
        public async Task<IActionResult> Authenticate(
            [FromBody]UserForAuthenticationDto userForAuthenticationDto)
        {
            var result = await _authenticationService
                .ValidateUserAsync(userForAuthenticationDto);

            if(!result)
                return Unauthorized();

            var token = await _authenticationService
                .CreateTokenAsync();

            return Ok(token);
        }
    }
}
