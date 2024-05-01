using Post_EDU.Core.Models;
using Post_EDU.Core.UploadModels;

namespace Post_EDU.Application.ServiceContracts
{
    public interface ICommentService
    {
        public Task CreateAsync(CommentUpload model, string userName);
        public Task<ICollection<Comment>> GetAsync(int postId);
        public Task DeleteAsync(int postId);
        public Task UpdateAsync(CommentUpload model);
    }
}
