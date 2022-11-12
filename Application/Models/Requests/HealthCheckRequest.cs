namespace Concave.Application.Models.Requests;

#region Usings

using System.Diagnostics.CodeAnalysis;

#endregion

/// <summary> A health check. </summary>
[ExcludeFromCodeCoverage]
public class HealthCheckRequest
{
    #region Public Properties

    /// <summary> Gets or sets the component. </summary>
    /// <value> The component. </value>
    public string Component { get; set; }

    /// <summary> Gets or sets information describing the error. </summary>
    /// <value> Information describing the error. </value>
    public string? ErrorDesc { get; set; }

    /// <summary> Gets or sets the status. </summary>
    /// <value> The status. </value>
    public string Status { get; set; }

    /// <summary> Gets or sets the tags. </summary>
    /// <value> The tags. </value>
    public IEnumerable<string> Tags { get; set; }

    #endregion
}