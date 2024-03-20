using MongoDB.Driver;
using TutoringPlatformBackEnd.Users.Models;

namespace TutoringPlatformBackEnd.Users.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public AuthService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Users");
            _usersCollection = database.GetCollection<User>("TutoringPlatform");
        }

        public async Task<User> RegisterAsync(SignupRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                Password = HashPassword(request.Password),
                // Additional properties based on request or defaults
            };
            await CreateUserAsync(user);
            return user;
        }

        public async Task<User> LoginAsync(LoginRequest request)
        {
            return await GetUserByEmailAsync(request.Email);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            return await _usersCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, user.Email);
            await _usersCollection.ReplaceOneAsync(filter, user);
        }

        public async Task DeleteUserAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            await _usersCollection.DeleteOneAsync(filter);
        }

        // Method to hash the password using BCrypt
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
