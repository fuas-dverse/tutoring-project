namespace TutoringPlatformBackEnd.Models
{
    public class SignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EducationLevel { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
    }
}
