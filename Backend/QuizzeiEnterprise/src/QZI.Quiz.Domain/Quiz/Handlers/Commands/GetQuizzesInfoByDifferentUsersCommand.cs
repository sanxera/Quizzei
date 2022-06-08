using FluentValidation;
using FluentValidation.Results;
using QZI.Quiz.Domain.Configuration;
using QZI.Quiz.Domain.Quiz.Handlers.Requests;
using QZI.Quiz.Domain.Quiz.Handlers.Response;
using ValidationException = QZI.Core.Exceptions.ValidationException;

namespace QZI.Quiz.Domain.Quiz.Handlers.Commands
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
                throw new ValidationException(ValidationResult);
        }
    }
}
