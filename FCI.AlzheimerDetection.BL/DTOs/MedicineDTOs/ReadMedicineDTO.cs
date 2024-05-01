namespace FCI.AlzheimerDetection.BL.DTOs.MedicineDTOs;

public sealed record ReadMedicineDTO
{
    public ReadMedicineDTO(string name, string description, string companyName, string adminName)
    {
        Name = name;
        Description = description;
        CompanyName = companyName;
        AdminName = adminName;
    }

    public string Name { get; init; }
    public string Description { get; init; }
    public string CompanyName { get; init; }

    public string AdminName { get; init; }
}