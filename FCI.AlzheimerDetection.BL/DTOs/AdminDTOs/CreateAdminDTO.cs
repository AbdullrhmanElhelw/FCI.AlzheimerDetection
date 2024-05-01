    namespace FCI.AlzheimerDetection.BL.DTOs.AdminDTOs;

public sealed record CreateAdminDTO
{
    public CreateAdminDTO(string firstName, string lastName, string password, string sSN, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        SSN = sSN;
        BirthDate = birthDate;
    }

    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Password { get; init; }
    public string SSN { get; init; }
    public DateTime BirthDate { get; init; }
}