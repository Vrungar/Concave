using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Concave.Application.AutoMapper;

using Concave.Contract.Mapping;

public static class MapperProfileHelper
{
    #region Public Methods and Operators

    /// <summary> Loads custom mappings. </summary>
    /// <param name="rootAssembly"> The root assembly. </param>
    /// <returns> The custom mappings. </returns>
    public static IList<IHaveCustomMapping> LoadCustomMappings(Assembly rootAssembly)
    {
        var types = rootAssembly.GetExportedTypes();

        var mapsFrom = (
                           from type in types
                           from instance in type.GetInterfaces()
                           where
                               typeof(IHaveCustomMapping).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface
                           select (IHaveCustomMapping)Activator.CreateInstance(type)).ToList();

        return mapsFrom;
    }

    /// <summary> Loads standard mappings. </summary>
    /// <param name="rootAssembly"> The root assembly. </param>
    /// <returns> The standard mappings. </returns>
    public static IList<Map> LoadStandardMappings(Assembly rootAssembly)
    {
        var types = rootAssembly.GetExportedTypes();

        var mapsFrom = (
                           from type in types
                           from interfaceType in type.GetInterfaces()
                           where
                               interfaceType.IsGenericType
                               && (interfaceType.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                                    || interfaceType.GetGenericTypeDefinition() == typeof(IMapTo<>))
                               && !type.IsAbstract
                               && !type.IsInterface
                           select interfaceType.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                               ? new Map
                               {
                                   Source = interfaceType.GetGenericArguments().First(),
                                   Destination = type
                               }
                               : new Map
                               {
                                   Destination = interfaceType.GetGenericArguments().First(),
                                   Source = type
                               }).ToList();

        return mapsFrom;
    }

    #endregion
}