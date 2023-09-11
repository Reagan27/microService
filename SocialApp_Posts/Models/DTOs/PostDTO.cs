namespace MicroService_Posts.Models.DTOs
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public IEnumerable<CommentDTO>? Comments { get; set; }
    }
}
