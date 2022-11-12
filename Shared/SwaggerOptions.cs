namespace Concave.Shared;

#region Usings

using System.Diagnostics.CodeAnalysis;

#endregion

/// <summary> A swagger options. </summary>
[ExcludeFromCodeCoverage]
public class SwaggerOptions
{
    #region Public Properties

    /// <summary> Gets or sets the description. </summary>
    /// <value> The description. </value>
    public string Description { get; set; }

    /// <summary> Gets or sets the endpoint. </summary>
    /// <value> The endpoint. </value>
    public string Endpoint { get; set; }

    /// <summary> Gets or sets the JSON route. </summary>
    /// <value> The JSON route. </value>
    public string JsonRoute { get; set; }

    /// <summary> Gets or sets the title. </summary>
    /// <value> The title. </value>
    public string Title { get; set; }

    /// <summary> Gets or sets the version. </summary>
    /// <value> The version. </value>
    public string Version { get; set; }

    #endregion
}