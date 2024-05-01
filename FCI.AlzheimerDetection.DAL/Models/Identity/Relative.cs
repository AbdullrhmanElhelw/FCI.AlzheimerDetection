namespace FCI.AlzheimerDetection.DAL.Models.Identity;

public class Relative : ApplicationUser
{
    public string SSN { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string RelationshipDegree { get; set; } = string.Empty;

    #region relations

    public ICollection<RelativeMedicine> RelativeMedicine { get; set; } = [];
    public ICollection<AddRelative> AddRelatives { get; set; } = [];

    #endregion relations
}