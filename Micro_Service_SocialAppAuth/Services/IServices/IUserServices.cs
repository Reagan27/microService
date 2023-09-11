using MicroServiceAuthentication.Models;

namespace MicroServiceAuthentication.Services.IServices
{
    public interface IUserServices
    {
        Task<string> RegisterUser(RegisterRequestDTO registerRequestDto);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);

        Task<bool> AssignUserRole(string email, string Rolename);
    }
}
