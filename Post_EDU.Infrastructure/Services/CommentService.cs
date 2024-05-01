using Post_EDU.Application.RepositoryContracts;
using Post_EDU.Application.ServiceContracts;
using Post_EDU.Core.Models;
using Post_EDU.Core.UploadModels;

namespace Post_EDU.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IUserRepository userRepository, ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task CreateAsync(CommentUpload model, string userName)
        {

            var user = await _userRepository.GetByNameAsync(userName);

            var comment = new Comment
            {
                PostId = model.PostId,
                TextComment = model.TextComment,
                DateOfComment = DateTime.Now,
                UserId = user.IdUser,
            };

            await _commentRepository.CreateAsync(comment);
        }

        public Task DeleteAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Comment>> GetAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CommentUpload model)
        {
            throw new NotImplementedException();
        }
    }
}
