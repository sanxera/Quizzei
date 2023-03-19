using System;
using System.Runtime.Serialization;
using QZI.Quizzei.Domain.Exceptions.Abstract;

namespace QZI.Quizzei.Domain.Exceptions;

public class GenericException : DomainException
{
    public GenericException(string message) : base(message)
    {
    }

    public GenericException(string message, Exception innerEx) : base(message, innerEx)
    {
    }

    public GenericException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}