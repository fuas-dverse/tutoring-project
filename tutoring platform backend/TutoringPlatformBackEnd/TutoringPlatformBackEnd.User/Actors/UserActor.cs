using Proto;
using System;
using System.Threading.Tasks;
using TutoringPlatformBackEnd.User.Models;
using TutoringPlatformBackEnd.User.Services;

namespace TutoringPlatformBackEnd.User.Actors
{
    public class UserActor
    {
        private readonly IAuthService _authService;

        public UserActor(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public async Task ReceiveAsync(IContext context)
        {
            switch (context.Message)
            {
                case SignupRequest signupRequest:
                    await RegisterUserAsync(context, signupRequest);
                    break;
                case LoginRequest loginRequest:
                    await LoginUserAsync(context, loginRequest);
                    break;
                case UpdateUserRequest updateUserRequest:
                    await UpdateUserAsync(context, updateUserRequest);
                    break;
                case DeleteUserRequest deleteUserRequest:
                    await DeleteUserAsync(context, deleteUserRequest);
                    break;
                // Handle other user-related messages as needed
                default:
                    // Handle unsupported message types
                    throw new InvalidOperationException($"Unsupported message type: {context.Message.GetType().Name}");
            }
        }

        private async Task RegisterUserAsync(IContext context, SignupRequest request)
        {
            try
            {
                // Perform null check on the request object
                if (request == null)
                {
                    // Send response message indicating invalid request
                    return;
                }

                var existingUser = await _authService.GetUserByEmailAsync(request.Email);
                if (existingUser != null)
                {
                    // Send response message indicating user already exists
                    return;
                }

                // Call the RegisterAsync method with the SignupRequest object
                var user = await _authService.RegisterAsync(request);

                // Send response message indicating successful user registration
                context.Respond(new RegistrationResult { Success = true, User = user });
            }
            catch (Exception ex)
            {
                // Send response message indicating failure to register user
                context.Respond(new RegistrationResult { Success = false, ErrorMessage = ex.Message });
            }
        }

        private async Task LoginUserAsync(IContext context, LoginRequest request)
        {
            try
            {
                var user = await _authService.LoginAsync(request);
                if (user != null)
                {
                    // Send response message indicating successful login
                    context.Respond(new LoginResult { Success = true, User = user });
                }
                else
                {
                    // Send response message indicating invalid email or password
                    context.Respond(new LoginResult { Success = false, ErrorMessage = "Invalid email or password" });
                }
            }
            catch (Exception ex)
            {
                // Send response message indicating failure to login
                context.Respond(new LoginResult { Success = false, ErrorMessage = ex.Message });
            }
        }

        private async Task UpdateUserAsync(IContext context, UpdateUserRequest request)
        {
            try
            {
                var existingUser = await _authService.GetUserByEmailAsync(request.Email);
                if (existingUser != null)
                {
                    // Update user properties based on request
                    existingUser.Name = request.Name;
                    existingUser.LastName = request.LastName;
                    existingUser.EducationLevel = request.EducationLevel;
                    existingUser.Age = request.Age;
                    existingUser.Specialization = request.Specialization;

                    await _authService.UpdateUserAsync(existingUser);

                    // Send response message indicating successful user update
                    context.Respond(new UpdateUserResult { Success = true });
                }
                else
                {
                    // Send response message indicating user not found
                    context.Respond(new UpdateUserResult { Success = false, ErrorMessage = "User not found" });
                }
            }
            catch (Exception ex)
            {
                // Send response message indicating failure to update user
                context.Respond(new UpdateUserResult { Success = false, ErrorMessage = ex.Message });
            }
        }

        private async Task DeleteUserAsync(IContext context, DeleteUserRequest request)
        {
            try
            {
                var existingUser = await _authService.GetUserByEmailAsync(request.Email);
                if (existingUser != null)
                {
                    await _authService.DeleteUserAsync(request.Email);

                    // Send response message indicating successful user deletion
                    context.Respond(new DeleteUserResult { Success = true });
                }
                else
                {
                    // Send response message indicating user not found
                    context.Respond(new DeleteUserResult { Success = false, ErrorMessage = "User not found" });
                }
            }
            catch (Exception ex)
            {
                // Send response message indicating failure to delete user
                context.Respond(new DeleteUserResult { Success = false, ErrorMessage = ex.Message });
            }
        }

    }
}
