namespace FCI.AlzheimerDetection.DAL.Models;

public class Image : AppFile
{
    #region relations

    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    #endregion relations
}