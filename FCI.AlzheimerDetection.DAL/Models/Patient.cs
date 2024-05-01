using FCI.AlzheimerDetection.DAL.Models.Identity;

namespace FCI.AlzheimerDetection.DAL.Models;

public class Patient
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string SSN { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    #region relations

    public int AdminId { get; set; }
    public Admin? Admin { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; } = false;

    public int ImageId { get; set; }
    public Image? Image { get; set; }

    public ICollection<AddRelative> AddRelatives { get; set; } = [];

    #endregion relations
}