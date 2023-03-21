using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QZI.Quizzei.API.Configuration.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var ex = context.Exception;

        context.ExceptionHandled = true;
        context.Result = new ObjectResult(ex);
        context.HttpContext.Response.StatusCode = 500;
    }
}