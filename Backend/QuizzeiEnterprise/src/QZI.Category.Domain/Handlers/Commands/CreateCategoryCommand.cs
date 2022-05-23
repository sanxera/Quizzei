using FluentValidation;
using FluentValidation.Results;
using QZI.Category.Domain.Configuration;
using QZI.Category.Domain.Handlers.Requests;
using QZI.Category.Domain.Handlers.Response;
using ValidationException = QZI.Core.Exceptions.ValidationException;

namespace QZI.Category.Domain.Handlers.Commands
{
    public class CreateCategoryCommand : Command<CreateCategoryResponse>
    {
        private readonly IValidator<CreateCategoryRequest> _validator;
        private ValidationResult _validationResult;
        public CreateCategoryRequest Request { get; set; }

        public CreateCategoryCommand(CreateCategoryRequest request)
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
