using System;
using System.Runtime.Serialization;
using DomainException = QZI.Core.Exceptions.Abstract.DomainException;

namespace QZI.Question.Domain.Questions.Exceptions
{
    internal class GetQuestionsException : DomainException
    {
        public GetQuestionsException(string message) : base(message) { }

        public GetQuestionsException(string message, Exception innerEx) : base(message, innerEx) { }

        public GetQuestionsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
