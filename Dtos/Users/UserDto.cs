using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "O email é obrigatório.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
