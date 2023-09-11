namespace MicroService_Comments.Models.DTOs
{
    public class CommentsRequestDTO
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string CommentText { get; set; } = string.Empty;
    }
}
