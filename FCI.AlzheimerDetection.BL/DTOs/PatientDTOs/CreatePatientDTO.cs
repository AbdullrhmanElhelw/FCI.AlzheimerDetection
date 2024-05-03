using FCI.AlzheimerDetection.DAL.Models;
using FluentValidation;

namespace FCI.AlzheimerDetection.BL.DTOs.PatientDTOs;

public sealed record CreatePatientDTO
{
    public CreatePatientDTO(string firstName, string lastName, string sSN, string city, string street, string zipCode, DateTime birthDate, string phone)
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
    public string Phone { get; init; } 

    public int AdminId { get; set; }
    
}

public class CreatePatientDTOValidator : AbstractValidator<CreatePatientDTO>
{
    public CreatePatientDTOValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty()
            .WithMessage("First Name Is Required")
            .MinimumLength(2).WithMessage("First Name Must Be At Least 2 Characters")
            .MaximumLength(50).WithMessage("First Name Must Be Less Than 50 Characters");

        RuleFor(p => p.LastName)
            .NotEmpty()
            .WithMessage("Last Name Is Required")
            .MinimumLength(2).WithMessage("Last Name Must Be At Least 2 Characters")
            .MaximumLength(50).WithMessage("Last Name Must Be Less Than 50 Characters");

        RuleFor(p => p.SSN)
            .NotEmpty()
            .WithMessage("SSN Is Required")
            .Length(14).WithMessage("SSN Must Be 14 Characters");

        RuleFor(p => p.City)
            .NotEmpty()
            .WithMessage("City Is Required")
            .MinimumLength(2).WithMessage("City Must Be At Least 2 Characters")
            .MaximumLength(50).WithMessage("City Must Be Less Than 50 Characters");

        RuleFor(p => p.Street)
            .NotEmpty()
            .WithMessage("Street Is Required")
            .MinimumLength(2).WithMessage("Street Must Be At Least 2 Characters")
            .MaximumLength(100).WithMessage("Street Must Be Less Than 100 Characters");

        RuleFor(p => p.ZipCode)
            .NotEmpty()
            .WithMessage("Zip Code Is Required")
            .Length(5).WithMessage("Zip Code Must Be 5 Characters");

        RuleFor(p => p.BirthDate)
            .NotEmpty()
            .WithMessage("Birth Date Is Required")
            .LessThan(DateTime.Now).WithMessage("Birth Date Must Be Less Than Current Date");

        RuleFor(p => p.Phone)
            .NotEmpty()
            .WithMessage("Phone Is Required")
            .Length(11).WithMessage("Phone Must Be 11 Characters");
    }
}