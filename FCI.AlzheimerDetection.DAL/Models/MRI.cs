namespace FCI.AlzheimerDetection.DAL.Models;

public class MRI : AppFile
{
    #region relations

    public ICollection<AdminMRI> AdminMRIs { get; set; } = [];
    public ICollection<NormalUserMRI> NormalUserMRIs { get; set; } = [];

    #endregion relations
}