namespace MicroService_Posts.Models.DTOs
{
    public class CommentDTO
    {
        public Guid CommentId { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
