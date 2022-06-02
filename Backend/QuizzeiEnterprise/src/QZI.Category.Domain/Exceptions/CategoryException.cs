using System;
using System.Runtime.Serialization;
using QZI.Core.Exceptions.Abstract;

namespace QZI.Category.Domain.Exceptions
{
    internal class CategoryException : DomainException
    {
        public CategoryException(string message) : base(message) { }

        public CategoryException(string message, Exception innerEx) : base(message, innerEx) { }

        public CategoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
