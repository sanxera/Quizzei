using FluentValidation;
using QZI.User.Domain.User.Handlers.Requests;

namespace QZI.User.Domain.User.Validations
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            
        }
    }
}
