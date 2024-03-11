using Microsoft.AspNetCore.Identity;
using BCrypt.Net;
namespace TutoringPlatformBackEnd.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EducationLevel { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }

        // Method to generate a secure password hash using BCrypt
        public void SetPassword(string password)
        {
            // Generate a salt for hashing
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Hash the password using the salt
            Password = BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        // Method to verify if a provided password matches the stored hash
        public bool VerifyPassword(string password)
        {
            // Use BCrypt Verify method to compare hashed password with provided password
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }
}
