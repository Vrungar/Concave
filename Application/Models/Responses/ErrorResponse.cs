namespace Concave.Application.Models.Responses;

using System.Diagnostics.CodeAnalysis;

using Concave.Domain.Enumerations;

using JetBrains.Annotations;

/// <summary> An error response. </summary>
[ExcludeFromCodeCoverage]
[UsedImplicitly]
public class ErrorResponse
{
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the Cart.Application.Dto.ErrorResponse class.
    /// </summary>
    /// <param name="errorType"> The type of the error. </param>
    /// <param name="message">   The message. </param>
    public ErrorResponse(ErrorType errorType, string? message)
    {
        ErrorType = errorType;
        Message = message;
    }

    #endregion

    #region Public Properties

    /// <summary> Gets the type of the error. </summary>
    /// <value> The type of the error. </value>
    public ErrorType ErrorType { get; }

    /// <summary> Gets the message. </summary>
    /// <value> The message. </value>
    public string? Message { get; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj"> The object to compare with the current object. </param>
    /// <returns>
    /// <see langword="true" /> if the specified object  is equal to the current object;
    /// otherwise, <see langword="false" />.
    /// </returns>
    /// <seealso cref="M:System.Object.Equals(object)"/>
    public override bool Equals(object obj)
    {
        if (obj == null
            || GetType() != obj.GetType())
        {
            return false;
        }

        var p = (ErrorResponse)obj;
        return ErrorType == p.ErrorType && Message == p.Message;
    }

    #endregion
}