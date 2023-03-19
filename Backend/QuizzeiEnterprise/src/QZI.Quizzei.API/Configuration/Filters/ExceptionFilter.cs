using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QZI.Quizzei.Domain.Exceptions;
using QZI.Quizzei.Domain.Exceptions.Models.Customers.Party.Ref.Data.Dir.Jd.Itg.Domain.Configurations.Models;

namespace QZI.Quizzei.API.Configuration.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var ex = context.Exception;
        var res = ResolveResponse(ex);
            
        context.ExceptionHandled = true;
        context.Result = new ObjectResult(res);
        context.HttpContext.Response.StatusCode = res.StatusCode;
    }

    private static Error ResolveResponse(Exception ex) => ex switch
    {
        DomainValidationException vex => Error.FromValidation(vex),
        _ => Error.FromDefault(ex)
    };
}