using FCI.AlzheimerDetection.BL.DTOs.PatientDTOs;
using FCI.AlzheimerDetection.DAL.Shared;

namespace FCI.AlzheimerDetection.BL.Managers.Abstractions;

public interface IPatientManager
{
    Task<Result> CreatePatient(int adminId, CreatePatientDTO patientDTO);

    Task<Result<IQueryable<ReadPatientDTO>>> GetAllPatients();

    Task<Result<ReadPatientDTO>> GetPatientById(int id);

    Task<Result> UpdatePatient(int id, UpdatePatientDTO patientDTO);

    Task<Result> DeletePatient(int id);

    Task<Result<IQueryable<ReadPatientDTO>>> GetAllPatientsWithPaging(int pageNumber, int pageSize);

    Task<Result<IQueryable<ReadPatientDTO>>> Search(string key);

    Task<Result<IQueryable<ReadPatientDTO>>> Search(string key, int pageNumber, int pageSize);
}