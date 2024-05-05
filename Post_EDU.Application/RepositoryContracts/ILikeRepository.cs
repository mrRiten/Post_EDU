using Post_EDU.Core.Models;

namespace Post_EDU.Application.RepositoryContracts
{
    public interface ILikeRepository
    {
        public Task CreateAsync(Like model);
        public Task<Like?> GetAsync(int postId, int? userId);
        public Task DeleteAsync(Like model);
    }
}
