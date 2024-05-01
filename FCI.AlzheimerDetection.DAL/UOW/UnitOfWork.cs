using FCI.AlzheimerDetection.DAL.Context;
using FCI.AlzheimerDetection.DAL.Repositories.Abstractions;
using FCI.AlzheimerDetection.DAL.Repositories.Impelementations;

namespace FCI.AlzheimerDetection.DAL.UOW;

public class UnitOfWork : IUnitOfWork
{
    private readonly AlzheimerDetectionDbContext _context;

    public UnitOfWork(AlzheimerDetectionDbContext context)
    {
        _context = context;
        patientRepository = new PatientRepository(context);
        addRelativeRepository = new AddRelativeRepository(context);
        medicineRepository = new MedicineRepository(context);
        adminMRIRepository = new AdminMRIRepository(context);
        normalUserMRIRepository = new NormalUserMRIRepository(context);
    }

    public IPatientRepository patientRepository { get; private set; }
    public IAddRelativeRepository addRelativeRepository { get; private set; }

    public IMedicineRepository medicineRepository { get; private set; }

    public IAdminMRIRepository adminMRIRepository { get; private set; }

    public INormalUserMRIRepository normalUserMRIRepository { get; private set; }

    public int Commit() => _context.SaveChanges();

    public void Dispose() => _context.Dispose();
}