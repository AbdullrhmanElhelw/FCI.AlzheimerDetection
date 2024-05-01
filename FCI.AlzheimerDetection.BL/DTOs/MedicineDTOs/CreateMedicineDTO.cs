using FluentValidation;

namespace FCI.AlzheimerDetection.BL.DTOs.MedicineDTOs;

public sealed record CreateMedicineDTO
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string CompanyName { get; init; } = string.Empty;

    public CreateMedicineDTO(string name, string description, string companyName)
    {
        Name = name;
        Description = description;
        CompanyName = companyName;
    }
}

public class CreateMedicineDTOValidator : AbstractValidator<CreateMedicineDTO>
{
    public CreateMedicineDTOValidator()
    {
        RuleFor(medicine => medicine.Name)
            .NotEmpty()
            .WithMessage("Name Is Required");

        RuleFor(medicine => medicine.CompanyName)
            .NotEmpty()
            .WithMessage("Company Name Is Required");
    }
}