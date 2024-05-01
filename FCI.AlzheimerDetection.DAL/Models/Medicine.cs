// Ignore Spelling: Admin

using FCI.AlzheimerDetection.DAL.Models.Identity;

namespace FCI.AlzheimerDetection.DAL.Models;

public class Medicine
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;

    #region relations

    public int AdminId { get; set; }
    public Admin? Admin { get; set; }

    public ICollection<RelativeMedicine> RelativeMedicine { get; set; } = [];

    #endregion relations
}