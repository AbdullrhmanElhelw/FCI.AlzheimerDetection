using FCI.AlzheimerDetection.DAL.Models.Identity;

namespace FCI.AlzheimerDetection.DAL.Models;

public class NormalUserMRI
{
    #region relations

    public int NormalUserId { get; set; }
    public NormalUser? NormalUser { get; set; }

    public int MRIId { get; set; }
    public MRI? MRI { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.Now;

    #endregion relations
}