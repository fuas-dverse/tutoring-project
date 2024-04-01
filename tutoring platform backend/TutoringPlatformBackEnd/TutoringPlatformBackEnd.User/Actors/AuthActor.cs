using Proto;
using TutoringPlatformBackEnd.Users.Models;
using TutoringPlatformBackEnd.Users.Services;

namespace TutoringPlatformBackEnd.Users.Actors

{
    public class AuthActor : IActor
    {
        private readonly IServiceProvider _serviceProvider;

        public AuthActor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        

        public async Task ReceiveAsync(IContext context)
        {
            switch (context.Message)
            {
                case SignupRequest signupRequest:
                    await HandleSignupRequestAsync(context, signupRequest);
                    break;
                case LoginRequest loginRequest:
                    await HandleLoginRequestAsync(context, loginRequest);
                    break;
                default:
                    // Handle unsupported message types
                    throw new InvalidOperationException($"Unsupported message type: {context.Message.GetType().Name}");
            }
        }

        private async Task HandleSignupRequestAsync(IContext context, SignupRequest request)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();

                // Register the user using the AuthService
                var user = await authService.RegisterAsync(request);

                // Respond with the registered user or success status
                context.Respond(new RegistrationResult { Success = true, User = user });
            }
            catch (Exception ex)
            {
                // Respond with an error message if registration fails
                context.Respond(new RegistrationResult { Success = false, ErrorMessage = ex.Message });
            }
        }

        private async Task HandleLoginRequestAsync(IContext context, LoginRequest request)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();

                // Authenticate the user using the AuthService
                var user = await authService.LoginAsync(request);

                if (user != null)
                {
                    // Respond with the authenticated user
                    context.Respond(new LoginResult { Success = true, User = user });
                }
                else
                {
                    // Respond with an error message if authentication fails
                    context.Respond(new LoginResult { Success = false, ErrorMessage = "Invalid email or password" });
                }
            }
            catch (Exception ex)
            {
                // Respond with an error message if login fails
                context.Respond(new LoginResult { Success = false, ErrorMessage = ex.Message });
            }
        }
    }
}
