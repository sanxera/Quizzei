using System;
using System.Runtime.Serialization;
using QZI.Quizzei.Domain.Exceptions.Abstract;

namespace QZI.Quizzei.Domain.Exceptions;

public class NotFoundException : DomainException
{
    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string message, Exception innerEx) : base(message, innerEx) { }

    public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}