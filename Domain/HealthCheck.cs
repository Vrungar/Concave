namespace Concave.Common.Models;

#region Usings

using System.Diagnostics.CodeAnalysis;

#endregion

/// <summary> A health check. </summary>
[ExcludeFromCodeCoverage]
public class HealthCheck // TODO: derive from entity base
{
    #region Fields

    private readonly Guid _healthCheckId;

    #endregion

    #region Constructors and Destructors

    public HealthCheck()
    {
        HealthCheckId = Guid.NewGuid();
    }

    #endregion

    #region Public Properties

    public Guid HealthCheckId
    {
        get => _healthCheckId;
        private init
        {
            _healthCheckId = value;
            PartitionKey = value.ToString();
        }
    }

    public string Name { get; set; } = "Test";

    public string? PartitionKey { get; init; }

    #endregion
}