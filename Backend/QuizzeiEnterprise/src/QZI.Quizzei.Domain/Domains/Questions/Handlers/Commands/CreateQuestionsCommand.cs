using System;
using FluentValidation;
using FluentValidation.Results;
using QZI.Quizzei.Domain.Configuration;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Requests;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Responses;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Questions.Handlers.Commands
{
    public class CreateQuestionsCommand : Command<CreateQuestionsResponse>
    {
        private readonly IValidator<CreateQuestionsRequest> _validator;
        private ValidationResult _validationResult;

        public Guid QuizInfoUuid { get; set; }
        public CreateQuestionsRequest Request { get; set; }

        public CreateQuestionsCommand(Guid quizInfoUuid, CreateQuestionsRequest request)
        {
            QuizInfoUuid = quizInfoUuid;
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
                throw new DomainValidationException(ValidationResult);
        }
    }
}
