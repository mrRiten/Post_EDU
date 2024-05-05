using Microsoft.EntityFrameworkCore;
using Post_EDU.Application.RepositoryContracts;
using Post_EDU.Core.Models;

namespace Post_EDU.Infrastructure.Repositories
{
    public class LikeRepository(ApplicationDbContext context) : ILikeRepository
    {
        public readonly ApplicationDbContext _context = context;

        public async Task CreateAsync(Like model)
        {
            await _context.Likes.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Like model)
        {
            
        }

        public async Task<Like?> GetAsync(int postId, int? userId)
        {
            return await _context.Likes
                .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
        }
    }
}
