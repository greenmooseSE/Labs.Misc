using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using MultipleExceptionHandlers.WebApi.Exceptions;

namespace MultipleExceptionHandlers.WebApi.ExceptionHandlers;

public class ItemNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
{
    #region Public members

    /// <inheritdoc />
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is ItemNotFoundException)
        {
            context.Result = new ContentResult
            {
                Content = "Uh oh, 404 on that one!",
                StatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }

    #endregion
}


