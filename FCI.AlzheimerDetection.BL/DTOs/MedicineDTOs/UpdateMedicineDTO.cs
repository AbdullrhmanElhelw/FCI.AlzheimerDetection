namespace FCI.AlzheimerDetection.BL.DTOs.MedicineDTOs;

public sealed record UpdateMedicineDTO
{
    public UpdateMedicineDTO(string name, string description, string companyName)
    {
        Name = name;
        Description = description;
        CompanyName = companyName;
    }

    public string Name { get; init; }
    public string Description { get; init; }
    public string CompanyName { get; init; }
}