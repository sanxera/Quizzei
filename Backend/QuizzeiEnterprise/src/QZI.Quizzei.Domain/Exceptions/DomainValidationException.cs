using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using FluentValidation.Results;
using QZI.Quizzei.Domain.Exceptions.Abstract;
using QZI.Quizzei.Domain.Exceptions.Models;

namespace QZI.Quizzei.Domain.Exceptions;

[Serializable]
public sealed class DomainValidationException : DomainException
{
    private readonly ValidationResult _validationResult;

    public DomainValidationException(ValidationResult validationResult)
        : base("Validation Error")
    {
        _validationResult = validationResult;
    }

    public IEnumerable<InnerError> GetErrors() =>
        _validationResult.Errors.Select(InnerError.FromValidation).ToList();

    private DomainValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base("Validation Error") { }
}