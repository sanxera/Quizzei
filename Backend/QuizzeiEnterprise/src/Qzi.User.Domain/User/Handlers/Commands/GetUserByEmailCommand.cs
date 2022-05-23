using FluentValidation;
using FluentValidation.Results;
using QZI.User.Domain.Configuration;
using QZI.User.Domain.User.Handlers.Requests;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Validations;

namespace QZI.User.Domain.User.Handlers.Commands
{
    public class GetUserByEmailCommand : Command<ConfirmExistingEmailResponse>
    {
        private readonly IValidator<GetUserByEmailRequest> _validator;
        private ValidationResult _validationResult;

        public GetUserByEmailCommand(GetUserByEmailRequest request)
        {
            Request = request;

            _validator = new ConfirmExistingEmailValidator();
        }

        public GetUserByEmailRequest Request { get; set; }

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
                throw new Core.Exceptions.ValidationException(ValidationResult);
        }
    }
}
