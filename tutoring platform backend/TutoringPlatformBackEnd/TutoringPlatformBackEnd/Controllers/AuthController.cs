using Microsoft.AspNetCore.Mvc;
using TutoringPlatformBackEnd.Models;
using TutoringPlatformBackEnd.Services;

namespace TutoringPlatformBackEnd.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly IUserService _userService;

            public AuthController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpPost("login")]
            public IActionResult Login(LoginRequest request)
            {
                var result = _userService.Login(request.Email, request.Password);
                if (result == null)
                    return Unauthorized("Invalid email or password");

                return Ok(result);
            }

            [HttpPost("signup")]
            public IActionResult Signup(SignupRequest request)
            {
                var result = _userService.Signup(request.Email, request.Password, request.AccountType, request.Name, request.LastName, request.EducationLevel, request.Age, request.Specialization);
                if (!result.Success)
                    return Conflict(result.Message);

                return Ok(result.Success);
            }
        }
}
