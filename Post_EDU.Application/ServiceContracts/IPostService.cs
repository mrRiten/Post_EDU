using Post_EDU.Core.Models;
using Post_EDU.Core.UploadModels;

namespace Post_EDU.Application.ServiceContracts
{
    public interface IPostService
    {
        public Task<ICollection<Post>> GetAllAsync();
        public Task<Post?> GetAsync(string slug);
        public Task<IndexTopModel> GetIndexAsync();
        public Task<CategoryPost> GetCategoryPostAsync(string categoryName);
        public Task CreateAsync(PostUpload model, string userName, string? pathImg);
        public Task EditLikeAsync(LikeUpload model, string userName);
        public Task UpdateAsync(PostUpload model);
        public Task DeleteAsync(string slug);
    }
}
