using TutoringPlatformBackEnd.Models;

namespace TutoringPlatformBackEnd.Services
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();

    }
}
