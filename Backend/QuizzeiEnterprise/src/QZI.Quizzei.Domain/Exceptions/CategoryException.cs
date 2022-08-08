using System;
using System.Runtime.Serialization;
using QZI.Quizzei.Domain.Exceptions.Abstract;

namespace QZI.Quizzei.Domain.Exceptions
{
    internal class CategoryException : DomainException
    {
        public CategoryException(string message) : base(message) { }

        public CategoryException(string message, Exception innerEx) : base(message, innerEx) { }

        public CategoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
