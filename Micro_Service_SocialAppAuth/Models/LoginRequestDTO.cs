using System.ComponentModel.DataAnnotations;

namespace MicroServiceAuthentication.Models
{
    public class LoginRequestDTO
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
