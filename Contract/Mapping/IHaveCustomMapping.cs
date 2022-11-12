namespace Concave.Contract.Mapping;

#region Usings

using AutoMapper;

#endregion

/// <summary> Interface for have custom mapping. </summary>
public interface IHaveCustomMapping
{
    #region Public Methods and Operators

    /// <summary> Creates the mappings. </summary>
    /// <param name="profile"> The profile. </param>
    void CreateMappings(Profile profile);

    #endregion
}