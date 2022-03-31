using System;
using System.Runtime.Serialization;
using QZI.Core.Exceptions.Abstract;

namespace QZI.User.Domain.User.Exceptions
{
    [Serializable]
    public sealed class CreateUserException : DomainException
    {
        public CreateUserException(string message) : base(message) { }
        public CreateUserException(string message, Exception innerEx) : base(message, innerEx) { }
        private CreateUserException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}
