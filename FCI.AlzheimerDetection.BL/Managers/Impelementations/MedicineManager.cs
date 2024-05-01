using FCI.AlzheimerDetection.BL.DTOs.MedicineDTOs;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.DAL.Models;
using FCI.AlzheimerDetection.DAL.Shared;
using FCI.AlzheimerDetection.DAL.UOW;
using Microsoft.EntityFrameworkCore;

namespace FCI.AlzheimerDetection.BL.Managers.Impelementations;

public class MedicineManager : IMedicineManager
{
    private readonly IUnitOfWork _unitOfWork;

    public MedicineManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Result> CreateMedicine(CreateMedicineDTO medicine, int adminId)
    {
        var newMedicine = new Medicine
        {
            Name = medicine.Name,
            Description = medicine.Description,
            CompanyName = medicine.CompanyName,
            AdminId = adminId
        };

        _unitOfWork.medicineRepository.Create(newMedicine);

        return _unitOfWork.Commit() == 0
            ? Task.FromResult(Result.Failure("Failed to create medicine"))
            : Task.FromResult(Result.Success());
    }

    public Task<Result> DeleteMedicine(int id)
    {
        var medicine = _unitOfWork.medicineRepository.GetById(id);
        if (medicine is null)
            return Task.FromResult(Result.Failure("Medicine not found"));

        _unitOfWork.medicineRepository.Delete(medicine);

        return _unitOfWork.Commit() == 0
            ? Task.FromResult(Result.Failure("Failed to delete medicine"))
            : Task.FromResult(Result.Success());
    }

    public Task<Result<IQueryable<ReadMedicineDTO>>> GetAllMedicines()
    {
        var medicines = _unitOfWork.medicineRepository.GetAll().Include(m => m.Admin)
            .Select(m => new ReadMedicineDTO(m.Name, m.Description, m.CompanyName, m.Admin.FirstName + ' ' + m.Admin.LastName));

        return Task.FromResult(Result.Success(medicines));
    }

    public Task<Result<ReadMedicineDTO>> GetMedicine(int id)
    {
        var medicine = _unitOfWork.medicineRepository.GetMedicineWithAdmin(id);
        if (medicine is null)
            return Task.FromResult(Result.Failure<ReadMedicineDTO>("Medicine not found"));

        var medicineDTO = new
            ReadMedicineDTO(medicine.Name, medicine.Description, medicine.CompanyName, medicine.Admin?.FirstName + ' ' + medicine.Admin?.LastName);
        return Task.FromResult(Result.Success(medicineDTO));
    }

    public Task<Result> UpdateMedicine(int id, UpdateMedicineDTO medicineDTO)
    {
        var checkMedicineIsExists = _unitOfWork.medicineRepository.GetById(id);
        if (checkMedicineIsExists is null)
            return Task.FromResult(Result.Failure("Medicine not found"));

        checkMedicineIsExists.Name = medicineDTO.Name;
        checkMedicineIsExists.Description = medicineDTO.Description;
        checkMedicineIsExists.CompanyName = medicineDTO.CompanyName;

        _unitOfWork.medicineRepository.Update(checkMedicineIsExists);

        return _unitOfWork.Commit() == 0
            ? Task.FromResult(Result.Failure("Failed to update medicine"))
            : Task.FromResult(Result.Success());
    }
}