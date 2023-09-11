using Microsoft.AspNetCore.Identity;

namespace MicroServiceAuthentication.Services.IServices
{
    public interface IJWtTokenGenerator
    {
        string GenerateToken( IdentityUser user , IEnumerable<string> roles);
    }
}
