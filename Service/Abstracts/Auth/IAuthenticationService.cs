
using Entity.Dtos.AuthDtos;
using Microsoft.AspNetCore.Identity;

namespace Service.Abstracts.Auth
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto);
        Task<bool> ValidateUserAsync(UserForAuthenticationDto userForAuthDto);
        Task<string> CreateTokenAsync();
    }
}
