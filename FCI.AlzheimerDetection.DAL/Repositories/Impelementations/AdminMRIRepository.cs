using FCI.AlzheimerDetection.DAL.Context;
using FCI.AlzheimerDetection.DAL.Models;
using FCI.AlzheimerDetection.DAL.Repositories.Abstractions;

namespace FCI.AlzheimerDetection.DAL.Repositories.Impelementations;

public class AdminMRIRepository : BaseRepository<AdminMRI>, IAdminMRIRepository
{
    public AdminMRIRepository(AlzheimerDetectionDbContext context) : base(context)
    {
    }
}