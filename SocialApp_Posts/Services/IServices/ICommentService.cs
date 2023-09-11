using MicroService_Posts.Models.DTOs;

namespace MicroService_Posts.Services.IServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetCommentsAsync(string PostID);
    }
}
