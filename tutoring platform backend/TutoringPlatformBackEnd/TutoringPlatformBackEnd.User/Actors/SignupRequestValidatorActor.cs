using FluentValidation;
using Proto;
using TutoringPlatformBackEnd.User.Models;
using System;
using System.Threading.Tasks;


namespace TutoringPlatformBackEnd.User.Actors
{
    public class SignupRequestValidatorActor : IActor
    {
        private readonly IValidator<SignupRequest> _validator;

        public SignupRequestValidatorActor(IValidator<SignupRequest> validator)
        {
            _validator = validator;
        }

        public async Task ReceiveAsync(IContext context)
        {
            switch (context.Message)
            {
                case SignupRequest request:
                    // Validate the signup request using FluentValidation
                    var validationResult = await _validator.ValidateAsync(request);

                    if (validationResult.IsValid)
                    {
                        // If request is valid, respond with success
                        context.Respond(new RegistrationResult { Success = true });
                    }
                    else
                    {
                        // If request is invalid, respond with errors
                        var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                        var errorMessage = string.Join(", ", errors);
                        context.Respond(new RegistrationResult { Success = false, ErrorMessage = errorMessage });
                    }
                    break;
                default:
                    // Handle unsupported message types
                    throw new InvalidOperationException($"Unsupported message type: {context.Message.GetType().Name}");
            }
        }
    }
}
