﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QZI.Core.Exceptions;
using QZI.Core.Models.Customers.Party.Ref.Data.Dir.Jd.Itg.Domain.Configurations.Models;

namespace QZI.Core.Filters
{
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
            ValidationException vex => Error.FromValidation(vex),
            _ => Error.FromDefault(ex)
        };
    }
}
