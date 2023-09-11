using System.Threading.Tasks;

namespace MicroService_Posts.Services.IServices
{
    public interface IUserService
    {
        Task<string> GetUserByIdAsync(string userId);
       
    }
}
