
using FluentValidation;
using FluentValidation.Results;
using QZI.Core.Exceptions;
using QZI.User.Domain.Configuration;
using QZI.User.Domain.User.Handlers.Requests;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Validations;
using ValidationException = QZI.Core.Exceptions.ValidationException;

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
                if (_validationResult is not null) return _validationResult;

                _validationResult = _validator.Validate(Request);

                return _validationResult;
            }
        }

        public override void Validate()
        {
            if (ValidationResult.Errors.Count > 0)
                throw new ValidationException(ValidationResult);
        }
    }
}
