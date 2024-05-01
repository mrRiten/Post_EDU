namespace Post_EDU.Application.RepositoryContracts
{
    public interface ILikeRepository
    {
        public Task CreateAsync(int postId, int userId);
        public Task DeleteAsync(int postId, int userId);
    }
}
