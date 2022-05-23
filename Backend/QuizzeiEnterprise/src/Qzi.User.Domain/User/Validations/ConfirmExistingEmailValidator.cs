using FluentValidation;
using QZI.User.Domain.User.Handlers.Requests;

namespace QZI.User.Domain.User.Validations
{
    public class ConfirmExistingEmailValidator : AbstractValidator<GetUserByEmailRequest>
    {
        public ConfirmExistingEmailValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty();
        }
    }
}
