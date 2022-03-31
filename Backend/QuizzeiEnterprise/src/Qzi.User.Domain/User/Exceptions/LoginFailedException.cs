using System;
using System.Runtime.Serialization;
using QZI.Core.Exceptions.Abstract;

namespace QZI.User.Domain.User.Exceptions
{
    [Serializable]
    public sealed class LoginFailedException : DomainException
    {
        public LoginFailedException(string message) : base(message) { }
        public LoginFailedException(string message, Exception innerEx) : base(message, innerEx) { }
        private LoginFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
