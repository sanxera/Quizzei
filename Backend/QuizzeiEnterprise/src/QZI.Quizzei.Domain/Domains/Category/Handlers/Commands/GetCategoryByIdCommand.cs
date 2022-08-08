using FluentValidation;
using FluentValidation.Results;
using QZI.Quizzei.Domain.Configuration;
using QZI.Quizzei.Domain.Domains.Category.Handlers.Requests;
using QZI.Quizzei.Domain.Domains.Category.Handlers.Response;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Category.Handlers.Commands
{
    public class GetCategoryByIdCommand : Command<GetCategoryByIdResponse>
    {
        private readonly IValidator<GetCategoryByIdRequest> _validator;
        private ValidationResult _validationResult;

        public GetCategoryByIdRequest Request { get; set; }

        public GetCategoryByIdCommand(GetCategoryByIdRequest request)
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
