using FluentValidation;
using QZI.User.Domain.User.Handlers.Requests;

namespace QZI.User.Domain.User.Validations
{
    public class LoginUserValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("O email informado não é validao, tente novamente com um novo email !");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Senha inválida, tente novamente");
        }
    }
}
