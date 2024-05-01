using FCI.AlzheimerDetection.DAL.Models;

namespace FCI.AlzheimerDetection.DAL.Repositories.Abstractions;

public interface IPatientRepository
    : IBaseRepository<Patient>
{
    IQueryable<Patient> Search(Func<Patient, bool> key, int pageNumber, int pageSize);
}