using Microsoft.AspNetCore.Mvc;
using TutoringPlatformBackEnd.Users.Services;
using TutoringPlatformBackEnd.Users.Models;

namespace TutoringPlatformBackEnd.Users.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_authService.Register(user))
            {
                return Ok("User registered successfully!");
            }

            return Conflict("User already exists!");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            if (_authService.Login(loginRequest.Email, loginRequest.Password))
            {
                return Ok("Login successful!");
            }

            return Unauthorized("Invalid email or password!");
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
