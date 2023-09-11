namespace MicroService_Posts.Models.DTOs
{
    public class PostRequestDTO
    {
        public string Title { get; set; }

        public string Body { get; set; } = string.Empty;
    }
}
