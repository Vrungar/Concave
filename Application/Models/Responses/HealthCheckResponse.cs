namespace Concave.Application.Models.Responses;

#region Usings

using System.Diagnostics.CodeAnalysis;

using Concave.Application.Models.Requests;

#endregion

/// <summary> A health check response. </summary>
[ExcludeFromCodeCoverage]
public class HealthCheckResponse
{
    #region Public Properties

    /// <summary> Gets or sets the build number. </summary>
    /// <value> The build number. </value>
    public string BuildNumber { get; set; }

    /// <summary> Gets or sets the components. </summary>
    /// <value> The components. </value>
    public IEnumerable<HealthCheckRequest> Components { get; set; }

    /// <summary> Gets or sets the duration. </summary>
    /// <value> The duration. </value>
    public TimeSpan Duration { get; set; }

    /// <summary> Gets or sets the status. </summary>
    /// <value> The status. </value>
    public string Status { get; set; }

    /// <summary> Gets or sets the Date/Time of the time stamp. </summary>
    /// <value> The time stamp. </value>
    public DateTime TimeStamp { get; set; }

    #endregion
}