namespace Concave.Application.Exceptions;

#region Usings

using FluentValidation.Results;

#endregion

/// <summary> Exception for signalling request validation errors. </summary>
/// <seealso cref="T:Exception"/>
public class RequestValidationException : Exception
{
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the Cart.Application.Exceptions.RequestValidationException
    /// class.
    /// </summary>
    public RequestValidationException()
        : base("One or more request validations have occurred.")
    {
        Failures = new Dictionary<string, string[]>();
    }

    /// <summary>
    /// Initializes a new instance of the Cart.Application.Exceptions.RequestValidationException
    /// class.
    /// </summary>
    /// <param name="failures"> The failures. </param>
    public RequestValidationException(List<ValidationFailure> failures)
        : this()
    {
        var propertyNames = failures.Select(e => e.PropertyName)
                                    .Distinct();

        foreach (var propertyName in propertyNames)
        {
            var propertyFailures = failures.Where(e => e.PropertyName == propertyName)
                                           .Select(e => e.ErrorMessage)
                                           .ToArray();

            Failures.Add(propertyName, propertyFailures);
        }
    }

    #endregion

    #region Public Properties

    /// <summary> Gets the failures. </summary>
    /// <value> The failures. </value>
    public IDictionary<string, string[]> Failures { get; }

    #endregion
}