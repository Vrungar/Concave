using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concave.Application.AutoMapper;

using System.Reflection;

using global::AutoMapper;

public class AutoMapperProfile : Profile
{
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
    /// </summary>
    public AutoMapperProfile()
    {
        LoadStandardMappings();
        LoadCustomMappings();
        LoadConverters();
    }

    #endregion

    #region Methods

    /// <summary> Loads the converters. </summary>
    private void LoadConverters()
    {
    }

    /// <summary> Loads custom mappings. </summary>
    private void LoadCustomMappings()
    {
        var mapsFrom = MapperProfileHelper.LoadCustomMappings(Assembly.GetExecutingAssembly());

        foreach (var map in mapsFrom)
        {
            map.CreateMappings(this);
        }
    }

    /// <summary> Loads standard mappings. </summary>
    private void LoadStandardMappings()
    {
        var mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

        foreach (var map in mapsFrom)
        {
            CreateMap(map.Source, map.Destination)
                .ReverseMap();
        }
    }

    #endregion
}