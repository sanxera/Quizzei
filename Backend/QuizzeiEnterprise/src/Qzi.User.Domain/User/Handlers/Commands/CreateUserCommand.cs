using FluentValidation;
using FluentValidation.Results;
using QZI.User.Domain.Configuration;
using QZI.User.Domain.User.Handlers.Requests;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Validations;

namespace QZI.User.Domain.User.Handlers.Commands
{
    public class CreateUserCommand : Command<CreateUserResponse>
    {
        private readonly IValidator<CreateUserRequest> _validator;
        private ValidationResult _validationResult;

        public CreateUserCommand(CreateUserRequest request)
        {
            Request = request;

            _validator = new CreateUserValidator();
        }

        public CreateUserRequest Request { get; set; }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is null)
                {
                    _validationResult = _validator.Validate(Request);
                }

                return _validationResult;
            }
        }
    }
}
