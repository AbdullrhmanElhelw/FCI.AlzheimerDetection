namespace FCI.AlzheimerDetection.BL.DTOs.RelativeDTOs;

public record AddRelativeDTO
{
    public AddRelativeDTO(string sSN, DateTime birthDate, string city, string street, string zipCode, string relationshipDegree, string firstName, string lastName)
    {
        SSN = sSN;
        BirthDate = birthDate;
        City = city;
        Street = street;
        ZipCode = zipCode;
        RelationshipDegree = relationshipDegree;
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string SSN { get; init; }
    public DateTime BirthDate { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public string ZipCode { get; init; }
    public string RelationshipDegree { get; init; }
}