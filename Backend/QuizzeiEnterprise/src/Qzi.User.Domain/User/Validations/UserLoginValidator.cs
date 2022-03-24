using FluentValidation;
using QZI.User.Domain.User.Handlers.Requests;

namespace QZI.User.Domain.User.Validations
{
    public class UserLoginValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
