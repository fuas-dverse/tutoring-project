using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutoringPlatformBackEnd.Users.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TutoringPlatformBackEnd.Users.Services;
using NUnit.Framework; 
using Moq;
using TutoringPlatformBackEnd.Users.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TutoringPlatformBackEnd.Users.Controllers.Tests
{
    [TestClass()]
    public class AuthControllerTests
    {
        private AuthController _authController;
        private Mock<IAuthService> _mockAuthService;

        [TestInitialize]
        public void Setup()
        {
            _mockAuthService = new Mock<IAuthService>();
            _authController = new AuthController(_mockAuthService.Object);
        }

        [TestMethod]
        public async Task Register_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var signupRequest = new SignupRequest
            {
                Email = "test@example.com",
                Password = "password"
                // Add other properties as needed
            };

            _mockAuthService.Setup(service => service.GetUserByEmailAsync(signupRequest.Email))
                .ReturnsAsync((User)null); // Simulate no existing user

            // Act
            var result = await _authController.Register(signupRequest) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Login_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var loginRequest = new LoginRequest
            {
                Email = "test@example.com",
                Password = "password"
            };

            var user = new User
            {
                Email = loginRequest.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(loginRequest.Password)
            };

            _mockAuthService.Setup(service => service.GetUserByEmailAsync(loginRequest.Email))
                .ReturnsAsync(user);

            // Act
            var actionResult = await _authController.Login(loginRequest);
            var result = actionResult as OkObjectResult;

            // Assert
            Assert.IsNotNull(result, "Result should not be null");

            // Check if the result value is null
            Assert.IsNotNull(result.Value, "Result value should not be null");

            // Print out the result value for inspection
            Console.WriteLine($"Result Value: {result.Value}");

        }
    }
}