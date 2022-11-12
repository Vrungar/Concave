namespace Concave.Repository;

#region Usings

using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

/// <summary> A dependency injection. </summary>
public static class DependencyInjection
{
    #region Public Methods and Operators

    /// <summary>
    /// An IServiceCollection extension method that adds a repository to 'configuration'.
    /// </summary>
    /// <param name="services">      The services to act on. </param>
    /// <param name="configuration"> The configuration. </param>
    public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
    }

    #endregion
}