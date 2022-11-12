namespace Concave.Shared;

#region Usings

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Microsoft.AspNetCore.Builder;

#endregion

/// <summary> An extensions. </summary>
[ExcludeFromCodeCoverage]
public static class Extensions
{
    #region Constants

    /// <summary> (Immutable) The date time format. </summary>
    public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

    /// <summary> (Immutable) The time span format. </summary>
    public const string TimeSpanFormat = @"dd\.hh\:mm\:ss\.fff";

    #endregion

    #region Public Methods and Operators

    /// <summary> A TimeSpan extension method that converts a value to a REST format. </summary>
    /// <param name="value"> The value to act on. </param>
    /// <returns> Value as a string. </returns>
    public static string ToRestFormat(this DateTime? value)
    {
        return value.HasValue ? ToRestFormat(value.Value) : ToRestFormat(DateTime.MinValue);
    }

    /// <summary> A TimeSpan extension method that converts a value to a REST format. </summary>
    /// <param name="value"> The value to act on. </param>
    /// <returns> Value as a string. </returns>
    public static string ToRestFormat(this DateTime value)
    {
        return value.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
    }

    /// <summary> A TimeSpan extension method that converts a value to a REST format. </summary>
    /// <param name="value"> The value to act on. </param>
    /// <returns> Value as a string. </returns>
    public static string ToRestFormat(this TimeSpan value)
    {
        return value.ToString(TimeSpanFormat);
    }

    /// <summary>
    /// An IApplicationBuilder extension method that handler, called when the use custom
    /// exception.
    /// </summary>
    /// <param name="builder"> The builder to act on. </param>
    /// <returns> An IApplicationBuilder. </returns>
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandler>();
    }

    #endregion

}