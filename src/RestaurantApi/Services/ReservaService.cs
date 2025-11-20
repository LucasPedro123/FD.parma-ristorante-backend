using RestaurantAPI.Data;
using RestaurantAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Services
{
    public class ReservaService
    {
        private readonly RestaurantContext _context;

        public ReservaService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public async Task<Reserva> CreateAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
                return false;

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
