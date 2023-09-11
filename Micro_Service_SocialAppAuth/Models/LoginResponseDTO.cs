namespace MicroServiceAuthentication.Models
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; } = default!;

        public string Token { get; set; } = string.Empty;
    }
}
