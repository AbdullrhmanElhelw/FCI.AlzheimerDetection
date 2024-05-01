using FCI.AlzheimerDetection.DAL.Models;

namespace FCI.AlzheimerDetection.BL.DTOs.PatientDTOs;

public sealed record ReadPatientDTO
{
    public ReadPatientDTO(string firstName, string lastName, string sSN, string city, string street, string zipCode, DateTime birthDate, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        SSN = sSN;
        City = city;
        Street = street;
        ZipCode = zipCode;
        BirthDate = birthDate;
        Phone = phone;
    }

    public string FirstName { get; init; }
    public string LastName { get; init; }

    public string SSN { get; init; }
    public string City { get; init; }

    public string Street { get; init; }
    public string ZipCode { get; init; }

    public DateTime BirthDate { get; init; }
    public string Phone { get; init; } = "01149160105";

    public static implicit operator ReadPatientDTO(Patient patient) =>
        new(patient.FirstName, patient.LastName, patient.SSN, patient.City, patient.Street, patient.ZipCode, patient.BirthDate, patient.Phone);
}