using FCI.AlzheimerDetection.BL.DTOs.MedicineDTOs;
using FCI.AlzheimerDetection.DAL.Shared;

namespace FCI.AlzheimerDetection.BL.Managers.Abstractions;

public interface IMedicineManager
{
    Task<Result> CreateMedicine(CreateMedicineDTO medicine, int adminId);

    Task<Result<ReadMedicineDTO>> GetMedicine(int id);

    Task<Result> DeleteMedicine(int id);

    Task<Result> UpdateMedicine(int id, UpdateMedicineDTO medicineDTO);

    Task<Result<IQueryable<ReadMedicineDTO>>> GetAllMedicines();
}