namespace FCI.AlzheimerDetection.DAL.Models.Identity;

public class NormalUser : ApplicationUser
{
    #region relations

    public ICollection<NormalUserMRI> NormalUserMRIs { get; set; } = [];

    #endregion relations
}