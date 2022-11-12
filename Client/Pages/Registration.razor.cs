#region Usings

#endregion

namespace Concave.Client.Pages;

#region Usings

//using Concave.Shared.Models.Requests;

using JetBrains.Annotations;

using Microsoft.AspNetCore.Components;

#endregion

/// <content> A registration. </content>
[UsedImplicitly]
public partial class Registration
{
    #region Public Properties

    /// <summary> Gets or sets the manager for navigation. </summary>
    /// <value> The navigation manager. </value>
    [Inject]
    public NavigationManager NavManager { get; set; }

    /// <summary> Gets or sets the registration request. </summary>
    /// <value> The registration request. </value>

    //public RegistrationRequest RegistrationRequest { get; set; }
    #endregion
}