using FluentValidation;
using FluentValidation.Results;
using QZI.Quizzei.Domain.Configuration;
using QZI.Quizzei.Domain.Domains.Category.Handlers.Requests;
using QZI.Quizzei.Domain.Domains.Category.Handlers.Response;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Category.Handlers.Commands
{
    public class GetAllCategoriesCommand : Command<GetAllCategoriesResponse>
    {
        private readonly IValidator<GetAllCategoriesRequest> _validator;
        private ValidationResult _validationResult;

        public GetAllCategoriesRequest Request { get; set; }

        public GetAllCategoriesCommand(GetAllCategoriesRequest request)
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
