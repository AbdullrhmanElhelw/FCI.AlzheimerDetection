using FCI.AlzheimerDetection.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.AlzheimerDetection.DAL.Configurations;

internal class RelativeMedicineConfiguration : IEntityTypeConfiguration<RelativeMedicine>
{
    public void Configure(EntityTypeBuilder<RelativeMedicine> builder)
    {
        builder.HasKey(a => new { a.RelativeId, a.MedicineId });
    }
}