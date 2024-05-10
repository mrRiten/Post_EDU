using Microsoft.EntityFrameworkCore;
using Post_EDU.Application.RepositoryContracts;
using Post_EDU.Core.Models;
using Post_EDU.Core.UploadModels;

namespace Post_EDU.Infrastructure.Repositories
{
    public class PostRepository(ApplicationDbContext context) : IPostRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task CreateAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Post>> GetAllAsync()
        {
            return await _context.Posts
                .Include(post => post.Author)
                .Include(post => post.Category)
                .ToListAsync();
        }

        public async Task<ICollection<Post>> GetByUserIdAsync(int userId)
        {
            return await _context.Posts
                .Where(p => p.AuthorId == userId)
                .ToListAsync();
        }

        public async Task<Post?> GetBySlugAsync(string slug)
        {
            return await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Slug == slug);
        }

        public Task UpdateAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task AddLikeAsync(int postId)
        {
            var post = await _context.Posts
                .FindAsync(postId);

            if (post != null)
            {
                post.LikeCount++;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteLikeAsync(int postId)
        {
            var post = await _context.Posts
                .FindAsync(postId);

            if (post != null)
            {
                post.LikeCount--;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post?>> GetTopByLikes()
        {
            return await _context.Posts
                .Include(p => p.Category)
                .Include(p => p.Category)
                .OrderByDescending(p => p.LikeCount)
                .Take(3)
                .ToListAsync();
        }

        public async Task<List<Post?>> GetTopByDate()
        {
            return await _context.Posts
                .Include(p => p.Category)
                .Include(p => p.Category)
                .OrderByDescending(p => p.DateOfCreate)
                .Take(3)
                .ToListAsync();
        }
    }
}
