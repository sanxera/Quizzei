using FluentValidation;
using QZI.User.Domain.User.Handlers.Requests;

namespace QZI.User.Domain.User.Validations
{
    public class ConfirmExistingEmailValidator : AbstractValidator<ConfirmExistingEmailRequest>
    {
        public ConfirmExistingEmailValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty();
        }
    }
}
