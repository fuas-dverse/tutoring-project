using FluentValidation;

namespace TutoringPlatformBackEnd.User.Models
{
    public class SignupRequestValidator : AbstractValidator<SignupRequest>
    {
        public SignupRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.AccountType).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();

            When(x => x.AccountType == "STUDENT", () =>
            {
                RuleFor(x => x.EducationLevel).NotEmpty().When(x => x.AccountType == "STUDENT");
                RuleFor(x => x.Age).NotEmpty().When(x => x.AccountType == "STUDENT");
            });

            When(x => x.AccountType == "TUTOR", () =>
            {
                RuleFor(x => x.Specialization).NotEmpty().When(x => x.AccountType == "TUTOR");
            });
        }
    }
}
