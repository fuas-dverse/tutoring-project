using TutoringPlatformBackEnd.Models;

namespace TutoringPlatformBackEnd.Services
{
    public interface IUserService
    {
        UserLoginResponse Login(string email, string password);
        UserSignupResponse Signup(string email, string password, string accountType, 
            string name, string lastName, string educationLevel, int age, string specialization);
    }
}
