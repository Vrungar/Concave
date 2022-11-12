#region Usings

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Concave.Application.Models.Requests;
using Concave.Application.Models.Responses;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;

#endregion

namespace Concave.Shared;

[ExcludeFromCodeCoverage]
public static class Utility
{
    #region Public Methods and Operators

    /// <summary> Health check response writer. </summary>
    /// <param name="context">      The context. </param>
    /// <param name="healthReport"> The health report. </param>
    /// <returns> An asynchronous result. </returns>
    public static Task HealthCheckResponseWriter(HttpContext context, HealthReport healthReport)
    {
        context.Response.ContentType = "application/json";
        var response = new HealthCheckResponse
                           {
                               Status = healthReport.Status.ToString(),
                               Components = healthReport.Entries.Select(x=>new HealthCheckRequest()),
                               Duration = healthReport.TotalDuration,
                               TimeStamp = DateTime.UtcNow,
                               BuildNumber = GetVersion()
                           };

        return context.Response.WriteAsJsonAsync(response);
    }

    #endregion

    #region Methods

    /// <summary> Gets the version. </summary>
    /// <returns> The version. </returns>
    private static string GetVersion()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

        return string.IsNullOrWhiteSpace(fileVersionInfo.ProductVersion)
                   ? "[BuildNumberNotPopulated]"
                   : fileVersionInfo.ProductVersion;
    }

    #endregion
}