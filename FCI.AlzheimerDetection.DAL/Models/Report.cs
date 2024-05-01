using FCI.AlzheimerDetection.DAL.Models.Identity;

namespace FCI.AlzheimerDetection.DAL.Models;

public class Report : AppFile
{
    #region relations

    public int AdminId { get; set; }
    public Admin? Admin { get; set; }

    #endregion relations
}