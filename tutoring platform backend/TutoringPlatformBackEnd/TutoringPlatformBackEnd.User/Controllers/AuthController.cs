using Microsoft.AspNetCore.Mvc;
using TutoringPlatformBackEnd.User.Models;
using TutoringPlatformBackEnd.User.Services;

namespace TutoringPlatformBackEnd.User.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;

        public AuthController(IAuthService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(SignupRequest request)
        {
            try
            {
                var existingUser = await _userService.GetUserByEmailAsync(request.Email);
                if (existingUser != null)
                {
                    return Conflict("User already exists");
                }

                var user = new UserModel
                {
                    Email = request.Email,
                    Password = HashPassword(request.Password),
                    // Additional properties based on request or defaults
                };

                await _userService.RegisterAsync(request);

                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to register user: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(request.Email);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                if (!VerifyPassword(request.Password, user.Password))
                {
                    return Unauthorized("Invalid email or password");
                }

                return Ok(new { message = "Login successful", user });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to login: {ex.Message}");
            }
        }

        // Method to hash the password using BCrypt
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Method to verify password using BCrypt
        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
