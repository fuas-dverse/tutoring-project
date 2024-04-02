using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TutoringPlatformBackEnd.Users.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using FluentValidation;
using TutoringPlatformBackEnd.Users.Services;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Net.Http.Json;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using TutoringPlatformBackEnd.Users;

namespace TutoringPlatformBackEnd.UsersTests.Integration
{
    [TestClass]
    public class AuthIntegrationTests
    {
        private TestServer _server;
        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Program>());
            _client = _server.CreateClient();
        }

        [TestCleanup]
        public void TearDown()
        {
            _client.Dispose();
            _server.Dispose();
        }

        [TestMethod]
        public async Task Register_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var signupRequest = new SignupRequest
            {
                Email = "test@example.com",
                Password = "password",
                // Additional properties as needed
            };

            // Act
            var response = await _client.PostAsJsonAsync("/auth/register", signupRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task Login_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var loginRequest = new LoginRequest
            {
                Email = "test@example.com",
                Password = "password",
            };

            // Act
            var response = await _client.PostAsJsonAsync("/auth/login", loginRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
