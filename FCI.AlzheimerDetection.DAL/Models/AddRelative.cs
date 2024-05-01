using FCI.AlzheimerDetection.DAL.Models.Identity;

namespace FCI.AlzheimerDetection.DAL.Models;

public class AddRelative
{
    #region relations

    public int AdminId { get; set; }
    public Admin? Admin { get; set; }

    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
    public int RelativeId { get; set; }
    public Relative? Relative { get; set; }

    public DateTime AddedOn { get; set; } = DateTime.UtcNow;

    #endregion relations
}