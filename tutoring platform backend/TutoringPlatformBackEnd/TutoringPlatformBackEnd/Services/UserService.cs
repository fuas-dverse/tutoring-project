using TutoringPlatformBackEnd.Models;

namespace TutoringPlatformBackEnd.Services
{
    public class UserService : IUserService
    {
        // For demonstration purposes, we'll use a simple in-memory list to store user data.
        private readonly List<User> _users = new List<User>();

        public UserService()
        {
            // Add some dummy users for demonstration
            _users.Add(new User { Email = "test1@example.com", Password = "password1", AccountType = "student" });
            _users.Add(new User { Email = "test2@example.com", Password = "password2", AccountType = "tutor" });
        }

        public UserLoginResponse Login(string email, string password)
        {
            // Find user by email
            var user = _users.Find(u => u.Email == email);

            if (user == null || user.Password != password)
            {
                return new UserLoginResponse { Success = false, Message = "Invalid email or password" };
            }

            // User authenticated successfully
            return new UserLoginResponse { Success = true, Message = "Login successful", User = user };
        }

        public UserSignupResponse Signup(string email, string password, string accountType, string name, string lastName, string educationLevel, int age, string specialization)
        {
            // Check if email is already registered
            if (_users.Exists(u => u.Email == email))
            {
                return new UserSignupResponse { Success = false, Message = "Email already registered" };
            }

            // Create new user
            var newUser = new User
            {
                Email = email,
                Password = password,
                AccountType = accountType,
                Name = name,
                LastName = lastName,
                EducationLevel = educationLevel,
                Age = age,
                Specialization = specialization
            };

            _users.Add(newUser);

            return new UserSignupResponse { Success = true, Message = "Signup successful", User = newUser };
        }
    }
}

