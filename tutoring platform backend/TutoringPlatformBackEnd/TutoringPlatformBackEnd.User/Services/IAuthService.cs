using TutoringPlatformBackEnd.Users.Models;

namespace TutoringPlatformBackEnd.Users.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(SignupRequest request);
        Task<User> LoginAsync(LoginRequest request);
        Task<User> GetUserByEmailAsync(string email);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string email);
    }
}
