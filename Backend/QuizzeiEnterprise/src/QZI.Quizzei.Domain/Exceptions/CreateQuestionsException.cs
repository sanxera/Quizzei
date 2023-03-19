using System;
using System.Runtime.Serialization;
using QZI.Quizzei.Domain.Exceptions.Abstract;

namespace QZI.Quizzei.Domain.Exceptions;

internal class CreateQuestionsException : DomainException
{
    public CreateQuestionsException(string message) : base(message) { }

    public CreateQuestionsException(string message, Exception innerEx) : base(message, innerEx) { }

    public CreateQuestionsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}