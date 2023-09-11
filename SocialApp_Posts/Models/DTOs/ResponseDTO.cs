namespace MicroService_Posts.Models
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
        public object Data { get; set; }
    }
}