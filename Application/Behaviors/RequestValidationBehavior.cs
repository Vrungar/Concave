namespace Concave.Application.Behaviors;

#region Usings

using System.Diagnostics.CodeAnalysis;

using Concave.Application.Exceptions;

using FluentValidation;

using MediatR;

#endregion

/// <summary> A request validation behavior. </summary>
/// <typeparam name="TRequest">  Type of the request. </typeparam>
/// <typeparam name="TResponse"> Type of the response. </typeparam>
/// <seealso cref="T:IPipelineBehavior{TRequest,TResponse}"/>
[ExcludeFromCodeCoverage]
public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    #region Fields

    /// <summary> (Immutable) The validators. </summary>
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the
    /// Cart.Application.Common.Behaviors.RequestValidationBehavior&lt;TRequest, TResponse&gt;
    /// class.
    /// </summary>
    /// <param name="validators"> The validators. </param>
    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// Pipeline handler. Perform any additional behavior and await the <paramref name="next" />
    /// delegate as necessary.
    /// </summary>
    /// <exception cref="RequestValidationException">
    ///     Thrown when a Request Validation error condition occurs.
    /// </exception>
    /// <param name="request">           Incoming request. </param>
    /// <param name="next">
    ///     Awaitable delegate for the next action in the pipeline. Eventually this delegate
    ///     represents the handler.
    /// </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <returns> Awaitable task returning the <typeparamref name="TResponse" /> </returns>
    /// <seealso cref="M:IPipelineBehavior.Handle(TRequest,RequestHandlerDelegate{TResponse},CancellationToken)"/>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var failures = _validators.Select(v => v.Validate(request))
                                  .SelectMany(result => result.Errors)
                                  .Where(f => f != null)
                                  .ToList();

        if (failures.Any())
        {
            throw new RequestValidationException(failures);
        }

        return await next();
    }

    #endregion
}