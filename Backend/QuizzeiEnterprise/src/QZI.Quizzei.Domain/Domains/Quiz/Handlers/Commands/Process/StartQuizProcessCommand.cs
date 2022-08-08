using FluentValidation;
using FluentValidation.Results;
using QZI.Quizzei.Domain.Configuration;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Requests.Process;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Response.Process;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Handlers.Commands.Process
{
    public class StartQuizProcessCommand : Command<StartQuizProcessResponse>
    {
        private readonly IValidator<StartQuizProcessRequest> _validator;
        private ValidationResult _validationResult;

        public string UserEmail { get; set; }
        public StartQuizProcessRequest Request { get; set; }

        public StartQuizProcessCommand(string userEmail, StartQuizProcessRequest request)
        {
            UserEmail = userEmail;
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