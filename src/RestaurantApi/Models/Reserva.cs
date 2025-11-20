using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public User? User { get; set; }

        [Required]
        public DateTime DataReserva { get; set; }

        [Required]
        public int NumeroPessoas { get; set; }

        public string Observacoes { get; set; } = string.Empty;
    }
}
