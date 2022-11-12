#region Usings

#endregion

namespace Concave.Shared;

using System.Net;

using Concave.Application.Exceptions;
using Concave.Common;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/// <summary> A custom exception handler. </summary>
public class CustomExceptionHandler
{
    #region Constants

    /// <summary> (Immutable) The error message template. </summary>
    public const string ErrorMessageUnhandled = "Unhandled exception.";

    /// <summary> (Immutable) Type of the HTTP response content. </summary>
    public const string HttpResponseContentType = "application/json";

    #endregion

    #region Fields

    /// <summary> (Immutable) The next. </summary>
    private readonly RequestDelegate _next;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the Cart.Api.Common.CustomExceptionHandler class.
    /// </summary>
    /// <param name="next"> The next. </param>
    public CustomExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// Executes the given operation on a different thread, and waits for the result.
    /// </summary>
    /// <param name="context"> The context. </param>
    /// <returns> An asynchronous result. </returns>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    #endregion

    #region Methods

    /// <summary> Handles the exception asynchronous. </summary>
    /// <param name="context">   The context. </param>
    /// <param name="exception"> The exception. </param>
    /// <returns> An asynchronous result. </returns>
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        ProblemDetails problemDetails;

        switch (exception)
        {
            case RequestValidationException validationException:
                problemDetails = ProblemDetailsBuilder.ValidationDetails(validationException.Failures);
                break;
            //case NotFoundException notFoundException:
            //    problemDetails = ProblemDetailsBuilder.NotFound(notFoundException.Message);
            //    break;
            default:
                problemDetails = ProblemDetailsBuilder.Error(ErrorMessageUnhandled);
                //Log.Error(exception, ErrorMessageUnhandled);
                break;
        }

        context.Response.ContentType = HttpResponseContentType;
        context.Response.StatusCode = problemDetails.Status ?? (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(""
            //JsonConvert.SerializeObject(
            //    problemDetails,
            //    new JsonSerializerSettings
            //    {
            //        DefaultValueHandling = DefaultValueHandling.Ignore
            //    })
            );
    }

    #endregion
}