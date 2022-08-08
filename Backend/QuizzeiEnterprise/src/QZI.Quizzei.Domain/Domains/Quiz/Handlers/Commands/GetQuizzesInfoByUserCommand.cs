using FluentValidation;
using FluentValidation.Results;
using QZI.Quizzei.Domain.Configuration;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Requests;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Response;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Handlers.Commands
{
    public class GetQuizzesInfoByUserCommand : Command<GetQuizzesInfoByUserResponse>
    {
        private readonly IValidator<GetQuizzesInfoByUserRequest> _validator;
        private ValidationResult _validationResult;

        public GetQuizzesInfoByUserRequest Request { get; set; }

        public GetQuizzesInfoByUserCommand(GetQuizzesInfoByUserRequest request)
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
                throw new DomainValidationException(ValidationResult);
        }
    }
}
