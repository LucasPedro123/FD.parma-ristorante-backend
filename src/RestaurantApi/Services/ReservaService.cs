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

        public async Task<List<Reserva>> GetAllAsync()
        {
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public async Task<Reserva> CreateAsync(ReservaRequest request)
        {
            var reserva = new Reserva
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                QuantidadePessoas = request.QuantidadePessoas,
                DataReserva = request.DataReserva,
                Observacoes = request.Observacoes
            };

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        public async Task<Reserva?> UpdateAsync(int id, ReservaRequest request)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
                return null;

            reserva.Nome = request.Nome;
            reserva.Telefone = request.Telefone;
            reserva.QuantidadePessoas = request.QuantidadePessoas;
            reserva.DataReserva = request.DataReserva;
            reserva.Observacoes = request.Observacoes;

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
