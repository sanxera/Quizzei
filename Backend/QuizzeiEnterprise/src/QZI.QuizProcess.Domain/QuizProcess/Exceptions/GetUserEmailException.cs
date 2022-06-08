using System;
using System.Runtime.Serialization;
using QZI.Core.Exceptions.Abstract;

namespace QZI.Quiz.Domain.Quiz.Exceptions
{
    internal class GetUserEmailException : DomainException
    {
        public GetUserEmailException(string message) : base(message) { }

        public GetUserEmailException(string message, Exception innerEx) : base(message, innerEx) { }

        public GetUserEmailException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
