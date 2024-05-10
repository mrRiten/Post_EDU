using Post_EDU.Core.Models;

namespace Post_EDU.Application.RepositoryContracts
{
    public interface ICategoryRepository
    {
        public Task<ICollection<Category>> GetAllAsync();
        public Task<Category> GetByNameAsync(string name);
    }
}
