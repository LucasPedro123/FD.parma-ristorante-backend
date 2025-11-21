using RestaurantAPI.Models;

namespace RestaurantAPI.Repositories
{
    public interface IMenuRepository
    {
        Task<MenuItem> CreateAsync(MenuItem item);
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<MenuItem?> GetByIdAsync(int id);
        Task AddAsync(MenuItem item);
        Task UpdateAsync(MenuItem item);
        Task DeleteAsync(MenuItem item);

    }
}
