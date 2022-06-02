using FluentValidation;
using FluentValidation.Results;
using QZI.Category.Domain.Configuration;
using QZI.Category.Domain.Handlers.Requests;
using QZI.Category.Domain.Handlers.Response;
using ValidationException = QZI.Core.Exceptions.ValidationException;

namespace QZI.Category.Domain.Handlers.Commands
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
                throw new ValidationException(ValidationResult);
        }
    }
}
