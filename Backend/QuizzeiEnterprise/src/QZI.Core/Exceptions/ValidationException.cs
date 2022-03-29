using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using QZI.Core.Abstract;
using QZI.Core.Models;

namespace QZI.Core.Exceptions
{
    [Serializable]
    public sealed class ValidationException : DomainException
    {
        private readonly ValidationResult _validationResult;

        public ValidationException(ValidationResult validationResult)
            : base("Validation Error")
        {
            _validationResult = validationResult;
        }

        public IEnumerable<InnerError> GetErrors() =>
            _validationResult.Errors.Select(InnerError.FromValidation).ToList();

        private ValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base("Validation Error") { }
    }
}
