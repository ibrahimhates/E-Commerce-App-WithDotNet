
using AutoMapper;
using Entity.Dtos.AuthDtos;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Abstracts.Auth;
using Service.Abstracts.LoggerAbstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Concrates.Auth
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private User? _user;

        public AuthenticationManager(
            ILoggerService logger, 
            IMapper mapper, 
            UserManager<User> userManager, 
            IConfiguration config)
        {
            _logger=logger;
            _mapper=mapper;
            _userManager=userManager;
            _config=config;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);
            user.CreatedDate = DateTime.Now;

            var result = await _userManager
                .CreateAsync(user, userForRegistrationDto.Password);

            return result;
        }
        public async Task<bool> ValidateUserAsync(UserForAuthenticationDto userForAuthDto)
        {
            _user = await _userManager.FindByNameAsync(userForAuthDto.UserName);

            var result = (_user is not null &&
                await _userManager.CheckPasswordAsync(_user, userForAuthDto.Password));

            return result;
        }
        public async Task<string> CreateTokenAsync()
        {
            var signinCredentials = GetSigninCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        private SigningCredentials GetSigninCredentials()
        {
            var jwtSetting = _config.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSetting["secretKey"]);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials,
            List<Claim> claims)
        {
            var jwtSetting = _config.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                    issuer: jwtSetting["validIssuer"],
                    audience: jwtSetting["validAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddDays(Convert.ToInt32(jwtSetting["expires"])),
                    signingCredentials: signinCredentials);

            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var list = new List<Claim>()
            {
                new Claim("key",_user.Id.ToString()),
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                list.Add(new Claim(ClaimTypes.Role, role));
            }

            return list;
        }

    }
}
