using Microsoft.EntityFrameworkCore;
using Post_EDU.Application.RepositoryContracts;
using Post_EDU.Core.Models;

namespace Post_EDU.Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(p => p.NameCategory == name);
        }
    }
}
