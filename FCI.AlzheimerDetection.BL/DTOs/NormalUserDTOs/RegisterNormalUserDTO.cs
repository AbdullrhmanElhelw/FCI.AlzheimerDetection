namespace FCI.AlzheimerDetection.BL.DTOs.NormalUserDTOs;

public sealed record RegisterNormalUserDTO
{
    public RegisterNormalUserDTO(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Email { get; init; }
    public string Password { get; init; }
}