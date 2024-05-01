using Post_EDU.Core.Models;

namespace Post_EDU.Application.ServiceContracts
{
    public interface IUserService
    {
        public Task<User?> GetAsync(int userId);
        public Task<User?> GetAsync(string name, string password);
        public Task<User?> GetAllInfoAsync(string userName);
        public Task CreateAsync(User user);
        public Task UpdateAsync(User user);
        public Task DeleteAsync(int userId);
    }
}
