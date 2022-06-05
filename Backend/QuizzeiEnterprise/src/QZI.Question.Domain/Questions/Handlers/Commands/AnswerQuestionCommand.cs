using FluentValidation;
using FluentValidation.Results;
using QZI.Question.Domain.Configuration;
using QZI.Question.Domain.Questions.Handlers.Requests;
using QZI.Question.Domain.Questions.Handlers.Responses;
using ValidationException = QZI.Core.Exceptions.ValidationException;

namespace QZI.Question.Domain.Questions.Handlers.Commands
{
    public class AnswerQuestionCommand : Command<AnswerQuestionResponse>
    {
        private readonly IValidator<AnswerQuestionRequest> _validator;
        private ValidationResult _validationResult;

        public string Email { get; set; }
        public AnswerQuestionRequest Request { get; set; }

        public AnswerQuestionCommand(string email, AnswerQuestionRequest request)
        {
            Email = email;
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
