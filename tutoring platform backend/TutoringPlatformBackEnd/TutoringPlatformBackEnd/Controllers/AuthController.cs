using Microsoft.AspNetCore.Mvc;
using TutoringPlatformBackEnd.Models;
using TutoringPlatformBackEnd.Services;

namespace TutoringPlatformBackEnd.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(SignupRequest request)
        {
            try
            {
                var user = new User
                {
                    Email = request.Email,
                    Password = request.Password,
                    AccountType = request.AccountType,
                    Name = request.Name,
                    LastName = request.LastName,
                    EducationLevel = request.EducationLevel,
                    Age = request.Age,
                    Specialization = request.Specialization
                };

                user.SetPassword(user.Password);
                await _userService.CreateUserAsync(user);

                var response = new UserSignupResponse
                {
                    Success = true,
                    Message = "User registered successfully",
                    User = user
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to register user: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userService.GetUserByEmailAsync(request.Email);
            if (user == null || !user.VerifyPassword(request.Password))
            {
                return BadRequest("Invalid email or password");
            }

            var response = new UserLoginResponse
            {
                Success = true,
                Message = "Login successful",
                User = user
            };

            return Ok(response);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
