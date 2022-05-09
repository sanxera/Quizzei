using System;
using System.Runtime.Serialization;
using QZI.Core.Exceptions.Abstract;

namespace QZI.Quiz.Domain.Quiz.Exceptions
{
    internal class NotFoundQuizInfoException : DomainException
    {
        public NotFoundQuizInfoException(string message) : base(message) { }

        public NotFoundQuizInfoException(string message, Exception innerEx) : base(message, innerEx) { }

        public NotFoundQuizInfoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}