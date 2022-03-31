using System;
using System.Runtime.Serialization;
using QZI.Core.Exceptions.Abstract;

namespace QZI.User.Domain.User.Exceptions
{
    public class UserAlreadyCreated : DomainException
    {
        public UserAlreadyCreated(string message) : base(message) { }
        public UserAlreadyCreated(string message, Exception innerEx) : base(message, innerEx) { }
        private UserAlreadyCreated(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
