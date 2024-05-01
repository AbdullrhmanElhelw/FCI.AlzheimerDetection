using FCI.AlzheimerDetection.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.AlzheimerDetection.DAL.Configurations;

internal class AdminMRIConfiguration : IEntityTypeConfiguration<AdminMRI>
{
    public void Configure(EntityTypeBuilder<AdminMRI> builder)
    {
        builder.HasKey(a => new { a.AdminId, a.MRIId });
    }
}