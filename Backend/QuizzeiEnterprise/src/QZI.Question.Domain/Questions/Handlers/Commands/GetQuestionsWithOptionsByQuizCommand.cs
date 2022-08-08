using FluentValidation;
using FluentValidation.Results;
using QZI.Question.Domain.Configuration;
using QZI.Question.Domain.Questions.Handlers.Requests;
using QZI.Question.Domain.Questions.Handlers.Responses;
using ValidationException = QZI.Core.Exceptions.ValidationException;

namespace QZI.Question.Domain.Questions.Handlers.Commands
{
    public class GetQuestionsWithOptionsByQuizCommand : Command<GetQuestionsWithOptionsByQuizResponse>
    {
        private readonly IValidator<GetQuestionsWithOptionsByQuizRequest> _validator;
        private ValidationResult _validationResult;

        public GetQuestionsWithOptionsByQuizRequest Request { get; set; }

        public GetQuestionsWithOptionsByQuizCommand(GetQuestionsWithOptionsByQuizRequest request)
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
