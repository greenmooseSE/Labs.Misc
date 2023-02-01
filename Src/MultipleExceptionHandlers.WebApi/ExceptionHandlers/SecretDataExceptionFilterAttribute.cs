using System;
using System.Linq;
using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using MultipleExceptionHandlers.WebApi.Exceptions;

namespace MultipleExceptionHandlers.WebApi.ExceptionHandlers;

public class SecretDataExceptionFilterAttribute : ExceptionFilterAttribute
{
    #region Public members

    /// <inheritdoc />
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is SecretDataException)
        {
            context.Result = new ContentResult
            {
                Content = "That data is a no-no!",
                StatusCode = (int)HttpStatusCode.Forbidden,
            };
        }
    }

    #endregion
}
