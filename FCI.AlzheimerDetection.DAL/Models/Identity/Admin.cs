namespace FCI.AlzheimerDetection.DAL.Models.Identity;

public class Admin : ApplicationUser
{
    public string SSN { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;

    #region relations

    public ICollection<Patient> Patients { get; set; } = [];

    public ICollection<AdminMRI> AdminMRIs { get; set; } = [];

    public ICollection<Report> Reports { get; set; } = [];

    public ICollection<Medicine> Medicines { get; set; } = [];
    public ICollection<AddRelative> AddRelatives { get; set; } = [];

    #endregion relations
}