using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.DTOs
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "O primeiro nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O primeiro nome deve ter no máximo 50 caracteres.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O sobrenome deve ter no máximo 50 caracteres.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O telefone deve conter 10 ou 11 dígitos numéricos.")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(User|Admin)$", ErrorMessage = "O campo Role deve ser 'User' ou 'Admin'.")]
        public string Role { get; set; } = "User";
    }
}
