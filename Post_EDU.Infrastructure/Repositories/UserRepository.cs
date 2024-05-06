using Microsoft.EntityFrameworkCore;
using Post_EDU.Application.RepositoryContracts;
using Post_EDU.Core.Models;

namespace Post_EDU.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserLoginTimeAsync(int userId, DateTime dateTime)
        {
            var user = await _context.Users.FindAsync(userId);
            user.LastLogin = dateTime;
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.IdUser == id);
        }

        public async Task<User?> GetByNameAsync(string name)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<User?> GetByNamePasswordAsync(string name, string password)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Name == name && u.Password == password);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
