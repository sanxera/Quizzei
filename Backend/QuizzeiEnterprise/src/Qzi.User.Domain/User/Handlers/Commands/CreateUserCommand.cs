using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using NetDevPack.Messaging;
using Qzi.User.Domain.Configuration;
using Qzi.User.Domain.User.Handlers.Requests;
using Qzi.User.Domain.User.Handlers.Responses;
using Qzi.User.Domain.User.Validations;

namespace Qzi.User.Domain.User.Handlers.Commands
{
    public class CreateUserCommand : Command<CreateUserResponse>
    {
        private readonly IValidator<CreateUserRequest> _validator;
        private ValidationResult _validationResult;

        public CreateUserCommand(CreateUserRequest request)
        {
            Request = request;

            _validator = new CreateUserValidator();
        }

        public CreateUserRequest Request { get; set; }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is null)
                {
                    _validationResult = _validator.Validate(Request);
                }

                return _validationResult;
            }
        }
    }
}
