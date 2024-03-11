namespace TutoringPlatformBackEnd.Models
{
    public class UserSignupResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        // to add additional properties if needed, such as newly created user details or tokens

        public User User { get; set; }
    }
}
