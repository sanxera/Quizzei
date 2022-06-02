using System;
using System.Runtime.Serialization;
using QZI.Core.Exceptions.Abstract;

namespace QZI.Core.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception innerEx) : base(message, innerEx) { }

        public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}