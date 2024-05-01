using FluentValidation;

namespace FCI.AlzheimerDetection.BL.DTOs.PatientDTOs;

public sealed record UpdatePatientDTO
    (string FirstName, string LastName, string City, string Street, string ZipCode, string Phone);

public class UpdatePatientDTOValidator : AbstractValidator<UpdatePatientDTO>
{
    public UpdatePatientDTOValidator()
    {
        RuleFor(u => u.FirstName)
            .MaximumLength(50)
            .WithMessage("The FirstName Must be less than 50 characters")
            .MinimumLength(2).WithMessage("The FirstName Must be grater than 2 characters")
            .NotEmpty();

        RuleFor(u => u.LastName)
            .MaximumLength(50)
            .WithMessage("The LastName Must be less than 50 characters")
            .MinimumLength(2)
            .WithMessage("The LastName Must be grater than 2 characters")
            .NotEmpty();

        RuleFor(u => u.City)
            .MaximumLength(50)
            .WithMessage("The City Must be less than 50 characters")
            .MinimumLength(2).WithMessage("The City  Must be grater than 2 characters")
            .NotEmpty();

        RuleFor(u => u.Street)
            .MaximumLength(100)
            .WithMessage("The Street Must be less than 50 characters")
            .MinimumLength(2)
            .WithMessage("The Street Must be grater than 2 characters")
            .NotEmpty();

        RuleFor(u => u.ZipCode)
            .Length(6)
            .WithMessage("ZipCode Must be 6 Numbers");

        RuleFor(u => u.Phone)
            .Length(11)
            .WithMessage("Phone Number Must be 11 Numbers");
    }
}