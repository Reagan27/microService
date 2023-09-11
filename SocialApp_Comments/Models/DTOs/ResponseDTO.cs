namespace MicroService_Comments.Models.DTOs
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
        public object Data { get; set; }
    }
}
