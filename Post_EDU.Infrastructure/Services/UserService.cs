using Post_EDU.Application.RepositoryContracts;
using Post_EDU.Application.ServiceContracts;
using Post_EDU.Core.Models;

namespace Post_EDU.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public UserService(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task CreateAsync(User user)
        {
            await _userRepository.CreateAsync(user);
        }

        public Task DeleteAsync(int userId)
        {
            throw new NotImplementedException();
        }

        // GET
        public async Task<User?> GetAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            user.Posts = await _postRepository.GetByUserIdAsync(userId);
            return user;
        }

        public async Task<User?> GetAsync(string name, string password)
        {
            return await _userRepository.GetByNamePasswordAsync(name, password);
        }

        public async Task<User?> GetAllInfoAsync(string userName)
        {
            var user = await _userRepository.GetByNameAsync(userName);
            user.Posts = await _postRepository.GetByUserIdAsync(user.IdUser);

            return user;
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
