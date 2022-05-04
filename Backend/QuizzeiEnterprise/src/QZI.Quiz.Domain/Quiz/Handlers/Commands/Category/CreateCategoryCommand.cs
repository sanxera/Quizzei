using FluentValidation;
using FluentValidation.Results;
using QZI.Quiz.Domain.Configuration;
using QZI.Quiz.Domain.Quiz.Handlers.Requests.Category;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Category;
using ValidationException = QZI.Core.Exceptions.ValidationException;

namespace QZI.Quiz.Domain.Quiz.Handlers.Commands.Category
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
