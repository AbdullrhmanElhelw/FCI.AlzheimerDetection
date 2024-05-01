using FCI.AlzheimerDetection.DAL.Context;
using FCI.AlzheimerDetection.DAL.Models;
using FCI.AlzheimerDetection.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FCI.AlzheimerDetection.DAL.Repositories.Impelementations;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    private readonly AlzheimerDetectionDbContext _context;

    public PatientRepository(AlzheimerDetectionDbContext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<Patient> Search(Func<Patient, bool> key, int pageNumber, int pageSize) =>
        _context.Patients
        .Where(key)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsQueryable()
        .AsNoTracking();
}