namespace Concave.Shared;

#region Usings

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

#endregion

/// <summary> A problem details builder. </summary>
public static class ProblemDetailsBuilder
{
    #region Public Methods and Operators

    /// <summary> Errors. </summary>
    /// <param name="message"> The message. </param>
    /// <returns> The ProblemDetails. </returns>
    public static ProblemDetails Error(string message)
    {
        return new ProblemDetails
                   {
                       Title = "Error",
                       Status = StatusCodes.Status500InternalServerError,
                       Detail = message
                   };
    }

    /// <summary> Invalid state. </summary>
    /// <param name="modelStates"> List of states of the models. </param>
    /// <returns> The ValidationProblemDetails. </returns>
    public static ValidationProblemDetails InvalidState(ModelStateDictionary modelStates)
    {
        var details = new ValidationProblemDetails
                          {
                              Status = StatusCodes.Status400BadRequest,
                              Title = "Invalid model state."
                          };

        foreach (var state in modelStates.Where(state => state.Value != null && state.Value.Errors.Any()))
        {
            details.Errors.Add(
                state.Key,
                state.Value?.Errors.Select(e => e.ErrorMessage)
                     .ToArray()
                ?? Array.Empty<string>());
        }

        return details;
    }

    /// <summary> Invalid version. </summary>
    /// <param name="message"> The message. </param>
    /// <returns> The ProblemDetails. </returns>
    public static ProblemDetails InvalidVersion(string message)
    {
        var errors = new Dictionary<string, string[]>
                         {
                             { "api-version", new[] { message } }
                         };
        return ValidationDetails(errors);
    }

    /// <summary> Not found. </summary>
    /// <param name="message"> The message. </param>
    /// <returns> The ProblemDetails. </returns>
    public static ProblemDetails NotFound(string message)
    {
        return new ProblemDetails
                   {
                       Title = "Not Found",
                       Status = StatusCodes.Status404NotFound,
                       Detail = message
                   };
    }

    /// <summary> Validation details. </summary>
    /// <param name="errors"> The errors. </param>
    /// <returns> The ValidationProblemDetails. </returns>
    public static ValidationProblemDetails ValidationDetails(IDictionary<string, string[]> errors)
    {
        var details = new ValidationProblemDetails
                          {
                              Status = StatusCodes.Status400BadRequest,
                              Title = "One or more validation errors occurred."
                          };

        foreach (var error in errors)
        {
            details.Errors.Add(error.Key, error.Value);
        }

        return details;
    }

    #endregion
}