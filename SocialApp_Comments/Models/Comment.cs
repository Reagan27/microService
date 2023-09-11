namespace MicroService_Comments.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public Guid PostId { get; set; }
        public string UserId { get; set; }
        public string CommentText { get; set; } = "";
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
