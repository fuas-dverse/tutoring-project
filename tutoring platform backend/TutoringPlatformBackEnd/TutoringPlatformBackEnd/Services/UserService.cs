using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using TutoringPlatformBackEnd.Models;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace TutoringPlatformBackEnd.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task CreateUserAsync(User user)
        {
            // Check if the user with the same email already exists
            if (await GetUserByEmailAsync(user.Email) != null)
            {
                throw new InvalidOperationException("User with the same email already exists.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}

