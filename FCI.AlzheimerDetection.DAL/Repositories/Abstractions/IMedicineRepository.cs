using FCI.AlzheimerDetection.DAL.Models;

namespace FCI.AlzheimerDetection.DAL.Repositories.Abstractions;

public interface IMedicineRepository : IBaseRepository<Medicine>
{
    Medicine GetMedicineWithAdmin(int id);
}