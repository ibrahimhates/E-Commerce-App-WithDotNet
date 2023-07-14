
using System.ComponentModel.DataAnnotations;

namespace Entity.Dtos.AuthDtos
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public String UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public String Password { get; init; }
    }
}
