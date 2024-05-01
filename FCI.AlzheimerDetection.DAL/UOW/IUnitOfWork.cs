using FCI.AlzheimerDetection.DAL.Repositories.Abstractions;

namespace FCI.AlzheimerDetection.DAL.UOW;

public interface IUnitOfWork : IDisposable
{
    IMedicineRepository medicineRepository { get; }

    IPatientRepository patientRepository { get; }
    IAddRelativeRepository addRelativeRepository { get; }
    IAdminMRIRepository adminMRIRepository { get; }
    INormalUserMRIRepository normalUserMRIRepository { get; }

    int Commit();
}