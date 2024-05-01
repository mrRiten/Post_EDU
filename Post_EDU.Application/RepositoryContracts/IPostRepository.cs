using Post_EDU.Core.Models;

namespace Post_EDU.Application.RepositoryContracts
{
    public interface IPostRepository
    {
        public Task<Post?> GetBySlugAsync(string slug);
        public Task<ICollection<Post>> GetAllAsync();
        public Task<ICollection<Post>> GetByUserIdAsync(int userId);
        public Task AddLike(int postId);
        public Task CreateAsync(Post post);
        public Task UpdateAsync(Post post);
        public Task DeleteAsync(string slug);
    }
}
