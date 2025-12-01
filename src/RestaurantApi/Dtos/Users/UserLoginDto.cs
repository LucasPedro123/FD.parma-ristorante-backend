using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Dtos.Users
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
