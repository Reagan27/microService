using MicroService_Posts.Services.IServices;

namespace MicroService_Posts.Services
{
    public class UserService : IUserService
    {
        public Task<string> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
