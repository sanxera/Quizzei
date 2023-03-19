﻿using System;
using System.Collections.Immutable;
using System.Net;
using System.Runtime.Serialization;
using QZI.Quizzei.Domain.Exceptions.Models;
using QZI.Quizzei.Domain.Exceptions.Models.Customers.Party.Ref.Data.Dir.Jd.Itg.Domain.Configurations.Models;

namespace QZI.Quizzei.Domain.Exceptions.Abstract;

[Serializable]
public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message) { }

    protected DomainException(string message, Exception innerEx) : base(message, innerEx) { }

    protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    public virtual string Title => "Unexpected Error";
    public virtual string Detail => "An unexpected error occurred";
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