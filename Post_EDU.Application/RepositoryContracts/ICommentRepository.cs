using Post_EDU.Core.Models;

namespace Post_EDU.Application.RepositoryContracts
{
    public interface ICommentRepository
    {
        public Task<ICollection<Comment>> GetByPostIdAsync(int postId);
        public Task CreateAsync(Comment comment);
        public Task UpdateAsync(Comment comment);
        public Task DeleteAsync(int id);
    }
}
