using FCI.AlzheimerDetection.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.AlzheimerDetection.DAL.Configurations;

internal class NormalUserMRIConfiguration : IEntityTypeConfiguration<NormalUserMRI>
{
    public void Configure(EntityTypeBuilder<NormalUserMRI> builder)
    {
        builder.HasKey(a => new { a.NormalUserId, a.MRIId });
    }
}