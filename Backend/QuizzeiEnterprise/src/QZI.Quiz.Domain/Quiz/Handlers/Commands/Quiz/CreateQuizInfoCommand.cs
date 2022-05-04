using FluentValidation;
using FluentValidation.Results;
using QZI.Quiz.Domain.Configuration;
using QZI.Quiz.Domain.Quiz.Handlers.Requests.Quiz;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Quiz;
using ValidationException = QZI.Core.Exceptions.ValidationException;

namespace QZI.Quiz.Domain.Quiz.Handlers.Commands.Quiz
{
    public class CreateQuizInfoCommand : Command<CreateQuizInfoResponse>
    {
        private readonly IValidator<CreateQuizInfoRequest> _validator;
        private ValidationResult _validationResult;

        public CreateQuizInfoRequest Request { get; set; }

        public CreateQuizInfoCommand(CreateQuizInfoRequest request)
        {
            Request = request;

            _validator = null;
        }

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
