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
        private readonly ICategoryRepository _categoryRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository,
            ICommentRepository commentRepository, ILikeRepository likeRepository, ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _likeRepository = likeRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task EditLikeAsync(LikeUpload model, string userName)
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
            }
            else
            {
                await _postRepository.DeleteLikeAsync(model.PostId);
                await _likeRepository.DeleteAsync(modelLike);
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

        public async Task<IndexTopModel> GetIndexAsync()
        {
            var indexModel = new IndexTopModel {
                TopLikesPosts = await _postRepository.GetTopByLikesAsync(),
                TopDatePosts = await _postRepository.GetTopByDateAsync()
            };

            return indexModel;
        }

        public async Task<CategoryPost> GetCategoryPostAsync(string categoryName)
        {
            var currentCategory = await _categoryRepository.GetByNameAsync(categoryName);

            var categoryPostModel = new CategoryPost
            {
                Categories = await _categoryRepository.GetAllAsync(),
                Posts = await _postRepository.GetByCategoryAsync(currentCategory.IdCategory),
                CurrentCategory = currentCategory,
            };

            return categoryPostModel;
        }
    }
}
