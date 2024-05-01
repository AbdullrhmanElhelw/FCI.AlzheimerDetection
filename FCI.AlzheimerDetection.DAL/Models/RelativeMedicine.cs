using FCI.AlzheimerDetection.DAL.Models.Identity;

namespace FCI.AlzheimerDetection.DAL.Models;

public class RelativeMedicine
{
    #region properties

    public bool IsAvailable { get; set; } = false;
    public DateTime Expired { get; set; } = DateTime.UtcNow.AddDays(10);
    public DateTime SetedOn { get; set; } = DateTime.UtcNow;

    #endregion properties

    #region relations

    public int RelativeId { get; set; }
    public Relative? Relative { get; set; }

    public int MedicineId { get; set; }
    public Medicine? Medicine { get; set; }

    #endregion relations
}