namespace TutoringPlatformBackEnd.User.Models
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public UserModel User { get; set; } // User object for successful login
    }
}
