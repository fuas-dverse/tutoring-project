using MongoDB.Driver;
using TutoringPlatformBackEnd.User.Models;

namespace TutoringPlatformBackEnd.User.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMongoCollection<UserModel> _usersCollection;

        public AuthService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Users");
            _usersCollection = database.GetCollection<UserModel>("TutoringPlatform");
        }

        public async Task<UserModel> RegisterAsync(SignupRequest request)
        {
            var user = new UserModel
            {
                Email = request.Email,
                Password = HashPassword(request.Password),
                // Additional properties based on request or defaults
            };
            await _usersCollection.InsertOneAsync(user);
            return user;
        }

        public async Task<UserModel> LoginAsync(LoginRequest request)
        {
            return await GetUserByEmailAsync(request.Email);
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var filter = Builders<UserModel>.Filter.Eq(u => u.Email, email);
            return await _usersCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateUserAsync(UserModel user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq(u => u.Email, user.Email);
            await _usersCollection.ReplaceOneAsync(filter, user);
        }

        public async Task DeleteUserAsync(string email)
        {
            var filter = Builders<UserModel>.Filter.Eq(u => u.Email, email);
            await _usersCollection.DeleteOneAsync(filter);
        }

        // Method to hash the password using BCrypt
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
