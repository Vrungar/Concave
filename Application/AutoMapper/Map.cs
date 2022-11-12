using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concave.Application.AutoMapper;

public sealed class Map
{
    #region Public Properties

    /// <summary> Gets or sets the Destination for the. </summary>
    /// <value> The destination. </value>
    public Type Destination { get; set; }

    /// <summary> Gets or sets the source for the. </summary>
    /// <value> The source. </value>
    public Type Source { get; set; }

    #endregion
}
