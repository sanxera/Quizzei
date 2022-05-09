using System;
using System.Runtime.Serialization;
using DomainException = QZI.Core.Exceptions.Abstract.DomainException;

namespace QZI.Quiz.Domain.Quiz.Exceptions
{
    internal class CreateQuestionsException : DomainException
    {
        public CreateQuestionsException(string message) : base(message) { }

        public CreateQuestionsException(string message, Exception innerEx) : base(message, innerEx) { }

        public CreateQuestionsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
