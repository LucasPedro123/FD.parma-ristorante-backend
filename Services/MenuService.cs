using RestaurantAPI.Models;
using RestaurantAPI.Repositories;


namespace RestaurantAPI.Services
{
    public class MenuService
    {
        private readonly IMenuRepository _repo;
        private readonly IWebHostEnvironment _env;

        public MenuService(IMenuRepository repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }

        public Task<IEnumerable<MenuItem>> GetAllAsync() => _repo.GetAllAsync();

        public Task<MenuItem?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task AddAsync(MenuItem item) => _repo.AddAsync(item);

        public Task CreateAsync(MenuItem item) => _repo.CreateAsync(item);

        public Task UpdateAsync(MenuItem item) => _repo.UpdateAsync(item);

        public async Task DeleteAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return;

            if (!string.IsNullOrEmpty(item.ImageUrl))
            {
                string path = Path.Combine(_env.WebRootPath, item.ImageUrl.TrimStart('/'));

                if (File.Exists(path))
                    File.Delete(path);
            }

            await _repo.DeleteAsync(item);
        }
    }
}
