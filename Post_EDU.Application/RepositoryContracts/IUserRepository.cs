using Post_EDU.Core.Models;

namespace Post_EDU.Application.RepositoryContracts
{
    public interface IUserRepository
    {
        public Task<User?> GetByIdAsync(int id);
        public Task<User?> GetByNamePasswordAsync(string name, string password);
        public Task<User?> GetByNameAsync(string name);
        public Task UpdateUserLoginTimeAsync(int userId, DateTime dateTime);
        public Task CreateAsync(User user);
        public Task UpdateAsync(User user);
        public Task DeleteAsync(User user);
    }
}
