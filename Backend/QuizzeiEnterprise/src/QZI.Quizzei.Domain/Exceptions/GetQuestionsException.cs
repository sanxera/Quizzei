using System;
using System.Runtime.Serialization;
using QZI.Quizzei.Domain.Exceptions.Abstract;

namespace QZI.Quizzei.Domain.Exceptions
{
    internal class GetQuestionsException : DomainException
    {
        public GetQuestionsException(string message) : base(message) { }

        public GetQuestionsException(string message, Exception innerEx) : base(message, innerEx) { }

        public GetQuestionsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
