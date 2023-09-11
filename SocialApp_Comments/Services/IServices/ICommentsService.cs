using MicroService_Comments.Models;

namespace MicroService_Comments.Services.IServices
{
    public interface ICommentsService
    {
        Task<string> CreateCommentAsync(Comment comment);
        Task<string> UpdateCommentAsync(Comment comment);
        Task<string> DeleteCommentAsync(Comment comment);
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<Comment> GetCommentByIdAsync(Guid commentId);
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId);
        Task<Comment> GetCommentsByUserIdAsync(string userId);
    }
}
