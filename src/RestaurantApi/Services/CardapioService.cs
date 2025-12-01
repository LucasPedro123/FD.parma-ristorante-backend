using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Dtos.Cardapio;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Services
{
    public class CardapioService
    {
        private readonly RestaurantContext _context;

        public CardapioService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<List<CardapioReadDto>> GetAllAsync()
        {
            return await _context.Cardapios
                .Select(c => new CardapioReadDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    Preco = c.Preco,
                    Disponivel = c.Disponivel,
                    Categoria = c.Categoria
                })
                .ToListAsync();
        }

        public async Task<CardapioReadDto?> GetByIdAsync(int id)
        {
            var item = await _context.Cardapios.FindAsync(id);
            if (item == null) return null;

            return new CardapioReadDto
            {
                Id = item.Id,
                Nome = item.Nome,
                Descricao = item.Descricao,
                Preco = item.Preco,
                Disponivel = item.Disponivel,
                Categoria = item.Categoria
            };
        }

        public async Task<Cardapio> CreateAsync(CardapioCreateDto dto)
        {
            var entity = new Cardapio
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                Disponivel = dto.Disponivel,
                Categoria = dto.Categoria
            };

            _context.Cardapios.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> UpdateAsync(int id, CardapioCreateDto dto)
        {
            var entity = await _context.Cardapios.FindAsync(id);
            if (entity == null) return false;

            entity.Nome = dto.Nome;
            entity.Descricao = dto.Descricao;
            entity.Preco = dto.Preco;
            entity.Disponivel = dto.Disponivel;
            entity.Categoria = dto.Categoria;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Cardapios.FindAsync(id);
            if (entity == null) return false;

            _context.Cardapios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
