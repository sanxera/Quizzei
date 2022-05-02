using System;
using System.Runtime.Serialization;
using DomainException = QZI.Core.Exceptions.Abstract.DomainException;

namespace QZI.Quiz.Domain.Quiz.Exceptions
{
    public class QuizInfoException : DomainException
    {
        public QuizInfoException(string message) : base(message) { }

        public QuizInfoException(string message, Exception innerEx) : base(message, innerEx) { }

        public QuizInfoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
