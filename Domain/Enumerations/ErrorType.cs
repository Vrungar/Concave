namespace Concave.Domain.Enumerations;

/// <summary> Values that represent error types. </summary>
public enum ErrorType
{
    /// <summary>The ErrorType has not been set. This should not occur in normal operations.</summary>
    None = 0,

    /// <summary>The Application or Domain layer has indicated that there is a problem with the requested action.</summary>
    BadRequest,

    /// <summary>The Application or Domain layer has indicated that the specified object cannot be found based in the Id passed.</summary>
    NotFound
}