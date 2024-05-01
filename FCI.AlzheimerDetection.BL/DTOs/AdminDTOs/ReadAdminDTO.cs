using FCI.AlzheimerDetection.DAL.Models.Identity;

namespace FCI.AlzheimerDetection.BL.DTOs.AdminDTOs;

public class ReadAdminDTO
{
    public ReadAdminDTO(string firstName, string lastName, string sSN, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        SSN = sSN;
        BirthDate = birthDate;
    }

    public string FirstName { get; init; }
    public string LastName { get; init; }

    public string SSN { get; init; }
    public DateTime BirthDate { get; init; }

    public static implicit operator ReadAdminDTO(Admin admin) =>
        new(admin.FirstName, admin.LastName, admin.SSN, admin.BirthDate);
}