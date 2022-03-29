using System;
using System.Collections.Immutable;
using System.Net;
using System.Runtime.Serialization;
using QZI.Core.Models;
using QZI.Core.Models.Customers.Party.Ref.Data.Dir.Jd.Itg.Domain.Configurations.Models;

namespace QZI.Core.Exceptions.Abstract
{
    [Serializable]
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {
        }

        protected DomainException(string message, Exception innerEx) : base(message, innerEx)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public virtual string Title => "unexpected error";
        public virtual string Detail => "an unexpected error occurred";
        public virtual HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public virtual Error Error => new Error
        {
            Errors = ImmutableList.Create(new InnerError
            {
                Title = Title,
                Detail = Detail,
                Status = ((int)StatusCode).ToString(),
            })
        };
    }
}
