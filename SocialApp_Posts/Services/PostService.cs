using Microsoft.EntityFrameworkCore;
using MicroService_Posts.Data;
using MicroService_Posts.Models;
using MicroService_Posts.Services.IServices;

namespace MicroService_Posts.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _context;

        public PostService(AppDbContext appDbContext)
        {
            _context = appDbContext;
            
        }
        // Create Post
        public async Task<string> CreatePostAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return "Post created successfully";
        }
        //Delete Post
        public async Task<string> DeletePostAsync(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return "Post Removed Successfully";
        }
        // Get All Posts
        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }
        
        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _context.Posts.Where(x => x.PostId == postId).FirstOrDefaultAsync();
        }
        // Get Post by UserID
        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(string userId)
        {
            var result = await _context.Posts.Where(x => x.UserId == userId).ToListAsync();
            return result;
        }
        // Post Updation
        public async Task<string> UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return "Post Updated Successfully";
        }
    }
}
