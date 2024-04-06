namespace TutoringPlatformBackEnd.User.Models
{
    public class RegistrationResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public UserModel User { get; set; } // User object for successful registration
    }
}
