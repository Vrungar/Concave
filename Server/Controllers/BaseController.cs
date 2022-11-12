namespace Concave.Server.Controllers;

using System.Diagnostics.CodeAnalysis;

using AutoMapper;

using Concave.Application.Models.Responses;
using Concave.Domain.Enumerations;
using Concave.Shared;

using CSharpFunctionalExtensions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

#region Usings

#endregion

[ExcludeFromCodeCoverage]
[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the Cart.Api.Controllers.BaseController class.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when one or more required arguments are null.
    /// </exception>
    /// <param name="mediator"> The mediator. </param>
    /// <param name="mapper">   The mapper. </param>
    protected BaseController(IMediator mediator, IMapper mapper)
    {
        Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    #endregion

    #region Properties

    /// <summary> Automapper. </summary>
    /// <value> The mapper. </value>
    protected IMapper Mapper { get; }

    /// <summary> Gets the mediator. </summary>
    /// <value> The mediator. </value>
    protected IMediator Mediator { get; }

    #endregion

    #region Methods

    /// <summary> Bad request. </summary>
    /// <param name="errorMessage"> Message describing the error. </param>
    /// <returns> A response stream to send to the BadRequest View. </returns>
    protected ActionResult BadRequest(string? errorMessage)
    {
        return BadRequest(ProblemDetailsBuilder.Error(errorMessage));
    }

    /// <summary> Generates an accepted API response. </summary>
    /// <typeparam name="TValueIn">  Type of the result's value. </typeparam>
    /// <typeparam name="TValueOut"> Type to return. </typeparam>
    /// <param name="result">      The result. </param>
    /// <param name="valueMapper"> Optional: Map the result's value to some other type. </param>
    /// <returns>
    /// A response stream to send to the GenerateAcceptedApiResponse&lt;TResult,EResult&gt;
    /// View.
    /// </returns>
    protected ActionResult GenerateAcceptedApiResponse<TValueIn, TValueOut>(
        Result<TValueIn, ErrorResponse> result,
        Func<TValueIn, TValueOut> valueMapper)
    {
        return result.IsFailure
                   ? GenerateErrorApiResponse(result.Error)
                   : new AcceptedResult("", valueMapper != null ? valueMapper(result.Value) : result.Value);
    }

    /// <summary> Generates a created API response. </summary>
    /// <typeparam name="TValueIn">  Type of the result's value. </typeparam>
    /// <typeparam name="TValueOut"> Type to return. </typeparam>
    /// <param name="result">      The result. </param>
    /// <param name="valueMapper"> Optional: Map the result's value to some other type. </param>
    /// <returns>
    /// A response stream to send to the GenerateCreatedApiResponse&lt;TResult,EResult&gt;
    /// View.
    /// </returns>
    protected ActionResult GenerateCreatedApiResponse<TValueIn, TValueOut>(
        Result<TValueIn, ErrorResponse> result,
        Func<TValueIn, TValueOut> valueMapper)
    {
        return result.IsFailure
                   ? GenerateErrorApiResponse(result.Error)
                   : new CreatedResult("", valueMapper != null ? valueMapper(result.Value) : result.Value);
    }

    /// <summary> Generates an error API response. </summary>
    /// <param name="errorResult"> The error result. </param>
    /// <returns> A response stream to send to the GenerateErrorApiResponse View. </returns>
    protected ActionResult GenerateErrorApiResponse(ErrorResponse? errorResult)
    {
        var result = errorResult?.ErrorType switch
            {
                ErrorType.NotFound => NotFound(errorResult.Message),
                _ => BadRequest(errorResult?.Message)
            };

        return result;
    }

    /// <summary> Generates an ok API response. </summary>
    /// <typeparam name="TValueIn">  Type of the result's value. </typeparam>
    /// <typeparam name="TValueOut"> Type to return. </typeparam>
    /// <param name="result">      The result. </param>
    /// <param name="valueMapper"> Optional: Map the result's value to some other type. </param>
    /// <returns>
    /// A response stream to send to the GenerateOkApiResponse&lt;TResult,EResult&gt; View.
    /// </returns>
    protected ActionResult GenerateOkApiResponse<TValueIn, TValueOut>(
        Result<TValueIn, ErrorResponse> result,
        Func<TValueIn, TValueOut> valueMapper)
    {
        return result.IsFailure
                   ? GenerateErrorApiResponse(result.Error)
                   : new OkObjectResult(valueMapper != null ? valueMapper(result.Value) : result.Value);
    }

    /// <summary> Not found. </summary>
    /// <param name="errorMessage"> Message describing the error. </param>
    /// <returns> A response stream to send to the NotFound View. </returns>
    protected ActionResult NotFound(string? errorMessage)
    {
        return base.NotFound(ProblemDetailsBuilder.NotFound(errorMessage));
    }

    #endregion
}