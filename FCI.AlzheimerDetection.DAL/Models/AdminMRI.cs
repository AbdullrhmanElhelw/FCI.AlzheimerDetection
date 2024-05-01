using FCI.AlzheimerDetection.DAL.Models.Identity;

namespace FCI.AlzheimerDetection.DAL.Models;

public class AdminMRI
{
    #region relations

    public int AdminId { get; set; }
    public Admin? Admin { get; set; }

    public int MRIId { get; set; }
    public MRI? MRI { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.Now;

    #endregion relations
}