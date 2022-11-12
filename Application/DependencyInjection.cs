namespace Concave.Application;

#region Usings

using System.Reflection;

using Concave.Application.Behaviors;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

/// <summary> A dependency injection. </summary>
public static class DependencyInjection
{
    #region Public Methods and Operators

    /// <summary>
    /// An IServiceCollection extension method that adds an application to 'configuration'.
    /// </summary>
    /// <param name="services">      The services to act on. </param>
    /// <param name="configuration"> The configuration. </param>
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        services.AddValidatorsFromAssembly(assembly);
        services.AddAutoMapper(assembly);
    }

    #endregion
}