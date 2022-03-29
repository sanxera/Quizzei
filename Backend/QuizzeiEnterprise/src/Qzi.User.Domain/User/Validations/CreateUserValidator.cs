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
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage($"O email informado é inválido !");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha informado é inválida !");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome informado é inválido !");

            RuleFor(x => x.ProfileId)
                .NotEmpty()
                .WithMessage("O perfil informado não existe !");
        }
    }
}
