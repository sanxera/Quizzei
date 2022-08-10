using FluentValidation;
using FluentValidation.Results;
using QZI.Quizzei.Domain.Configuration;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Requests.Information;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Response.Information;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Handlers.Commands.Information
{
    public class GetQuizzesInfoByDifferentUsersCommand : Command<GetQuizzesInfoByDifferentUsersResponse>
    {
        private readonly IValidator<GetQuizzesInfoByDifferentUsersRequest> _validator;
        private ValidationResult _validationResult;

        public GetQuizzesInfoByDifferentUsersRequest ByDifferentUsersRequest { get; set; }

        public GetQuizzesInfoByDifferentUsersCommand(GetQuizzesInfoByDifferentUsersRequest byDifferentUsersRequest)
        {
            ByDifferentUsersRequest = byDifferentUsersRequest;

            _validator = null;
        }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is not null) return _validationResult;

                _validationResult = _validator.Validate(ByDifferentUsersRequest);

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
