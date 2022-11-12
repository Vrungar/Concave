namespace Concave.Shared.Models.Requests;

/// <summary> A registration request. </summary>
public class RegistrationRequest
{
    #region Ids

    /// <summary> Gets the identifier of the correlation. </summary>
    /// <value> The identifier of the correlation. </value>
    public Guid CorrelationId { get; } = Guid.NewGuid();

    #endregion

    #region Public Properties

    /// <summary> Gets the registrants. </summary>
    /// <value> The registrants. </value>
    public List<RegistrantModel> Registrants { get; } = new();

    #endregion

    #region Public Methods and Operators

    /// <summary> Adds a registrant. </summary>
    /// <param name="registrant"> The registrant. </param>
    public void AddRegistrant(RegistrantModel registrant)
    {
        registrant.CorelationId = CorrelationId;
    }

    #endregion
}