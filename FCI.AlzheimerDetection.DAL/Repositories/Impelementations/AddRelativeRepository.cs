using FCI.AlzheimerDetection.DAL.Context;
using FCI.AlzheimerDetection.DAL.Models;
using FCI.AlzheimerDetection.DAL.Repositories.Abstractions;

namespace FCI.AlzheimerDetection.DAL.Repositories.Impelementations;

public class AddRelativeRepository : BaseRepository<AddRelative>, IAddRelativeRepository
{
    public AddRelativeRepository(AlzheimerDetectionDbContext context) : base(context)
    {
    }
}