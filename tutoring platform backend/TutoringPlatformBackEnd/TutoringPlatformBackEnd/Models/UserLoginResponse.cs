namespace TutoringPlatformBackEnd.Models
{
    public class UserLoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        // to add additional properties if needed, such as user details or tokens
        public User User { get; set; }
    }
}
