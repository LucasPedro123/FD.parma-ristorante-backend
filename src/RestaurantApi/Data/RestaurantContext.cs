using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

    }
}
