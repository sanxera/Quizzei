using FluentValidation;
using FluentValidation.Validators;
using QZI.User.Domain.User.Handlers.Requests;

namespace QZI.User.Domain.User.Validations
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);

            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
