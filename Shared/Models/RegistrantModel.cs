namespace Concave.Shared.Models;

/// <summary> A registrant. </summary>
public class RegistrantModel
{
    #region Ids

    /// <summary> Gets or sets the identifier of the corelation. </summary>
    /// <value> The identifier of the corelation. </value>
    public Guid CorelationId { get; set; }

    #endregion

    #region Public Properties

    /// <summary> Gets or sets the age. </summary>
    /// <value> The age. </value>
    public int Age { get; set; }

    /// <summary> Gets or sets the name of the badge. </summary>
    /// <value> The name of the badge. </value>
    public string BadgeName { get; set; }

    /// <summary> Gets or sets the email. </summary>
    /// <value> The email. </value>
    public string Email { get; set; }

    /// <summary> Gets or sets the person's first name. </summary>
    /// <value> The name of the first. </value>
    public string FirstName { get; set; }

    /// <summary> Gets or sets the person's last name. </summary>
    /// <value> The name of the last. </value>
    public string LastName { get; set; }

    #endregion
}