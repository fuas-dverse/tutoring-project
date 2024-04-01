namespace TutoringPlatformBackEnd.Users.Models
{
    public class RegistrationResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public User User { get; set; } // User object for successful registration
    }
}
