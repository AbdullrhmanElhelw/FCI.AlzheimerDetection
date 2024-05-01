using FCI.AlzheimerDetection.DAL.Context;
using FCI.AlzheimerDetection.DAL.Models;
using FCI.AlzheimerDetection.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FCI.AlzheimerDetection.DAL.Repositories.Impelementations;

public class MedicineRepository : BaseRepository<Medicine>, IMedicineRepository
{
    private readonly AlzheimerDetectionDbContext _context;

    public MedicineRepository(AlzheimerDetectionDbContext context) : base(context)
    {
        _context = context;
    }

    public Medicine GetMedicineWithAdmin(int id)
    {
        return _context
            .Medicines.Include(m => m.Admin).FirstOrDefault(m => m.Id == id)!;
    }
}