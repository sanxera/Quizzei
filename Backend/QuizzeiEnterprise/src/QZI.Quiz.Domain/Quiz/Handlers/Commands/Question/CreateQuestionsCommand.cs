using FluentValidation;
using FluentValidation.Results;
using QZI.Quiz.Domain.Configuration;
using QZI.Quiz.Domain.Quiz.Handlers.Requests.Questions;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Question;
using ValidationException = QZI.Core.Exceptions.ValidationException;

namespace QZI.Quiz.Domain.Quiz.Handlers.Commands.Question
{
    public class CreateQuestionsCommand : Command<CreateQuestionsResponse>
    {
        private readonly IValidator<CreateQuestionsRequest> _validator;
        private ValidationResult _validationResult;
        public CreateQuestionsRequest Request { get; set; }

        public CreateQuestionsCommand(CreateQuestionsRequest request)
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
