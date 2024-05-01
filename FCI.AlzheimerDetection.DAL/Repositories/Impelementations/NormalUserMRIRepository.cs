using FCI.AlzheimerDetection.DAL.Context;
using FCI.AlzheimerDetection.DAL.Models;
using FCI.AlzheimerDetection.DAL.Repositories.Abstractions;

namespace FCI.AlzheimerDetection.DAL.Repositories.Impelementations;

public class NormalUserMRIRepository : BaseRepository<NormalUserMRI>, INormalUserMRIRepository
{
    public NormalUserMRIRepository(AlzheimerDetectionDbContext context) : base(context)
    {
    }
}