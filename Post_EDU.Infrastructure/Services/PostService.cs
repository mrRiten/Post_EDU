using Microsoft.Identity.Client;
using Post_EDU.Application.RepositoryContracts;
using Post_EDU.Application.ServiceContracts;
using Post_EDU.Core.Models;
using Post_EDU.Core.UploadModels;

namespace Post_EDU.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ILikeRepository _likeRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository,
            ICommentRepository commentRepository, ILikeRepository likeRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _likeRepository = likeRepository;
        }

        public async Task AddLikeAsync(LikeUpload model, string userName)
        {
            var user = await _userRepository.GetByNameAsync(userName);
            
            if (user == null) { return; }

            var modelLike = await _likeRepository.GetAsync(model.PostId, user.IdUser);
                
            if (modelLike == null)
            {
                var like = new Like
                {
                    PostId = model.PostId,
                    UserId = user.IdUser
                };

                await _postRepository.AddLikeAsync(like.PostId);
                await _likeRepository.CreateAsync(like);
                return;
            }



        }

        public async Task CreateAsync(PostUpload model, string userName, string? pathImg)
        {
            var user = await _userRepository.GetByNameAsync(userName);

            var slugHelper = new SlugHelper();
            var post = new Post
            {
                Title = model.Title,
                Description = model.Description,
                Text = model.Text,
                Slug = slugHelper.Active(model.Title),

                LikeCount = 0,

                DateOfCreate = DateTime.Now,
                DateOfEdit = DateTime.Now,

                AuthorId = user.IdUser,
                CategoryId = model.CategoryId,

                PathImg = pathImg
            };

            await _postRepository.CreateAsync(post);
        }

        public Task DeleteAsync(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Post>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post?> GetAsync(string slug)
        {
            var post = await _postRepository.GetBySlugAsync(slug);
            var comments = await _commentRepository.GetByPostIdAsync(post.IdPost);
            post.Comments = comments;
            return post;
        }

        public Task UpdateAsync(PostUpload model)
        {
            throw new NotImplementedException();
        }
    }
}
