using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
