using TutoringPlatformBackEnd.Users.Models;

namespace TutoringPlatformBackEnd.Users.Services
{
    public class AuthService
    {
        // Dummy database
        private static readonly List<User> users = new List<User>();

        public bool Register(User user)
        {
            if (UserExists(user.Email))
            {
                return false; // User already exists
            }

            users.Add(user);
            return true; // Successfully registered
        }

        public bool Login(string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user != null; // If user is found with matching credentials
        }

        private bool UserExists(string email)
        {
            return users.Any(u => u.Email == email);
        }
    }
}
