using TutoringPlatformBackEnd.User.Models;

namespace TutoringPlatformBackEnd.User.Services
{
    public interface IAuthService
    {
        Task<UserModel> RegisterAsync(SignupRequest request);
        Task<UserModel> LoginAsync(LoginRequest request);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(string email);
    }
}
