using System.ComponentModel.DataAnnotations;

namespace TutoringPlatformBackEnd.User.Models
{
    public class SignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EducationLevel { get; set; } // Only for STUDENT
        public int Age { get; set; } // Only for STUDENT
        public string Specialization { get; set; } // Only for TUTOR
    }
}
