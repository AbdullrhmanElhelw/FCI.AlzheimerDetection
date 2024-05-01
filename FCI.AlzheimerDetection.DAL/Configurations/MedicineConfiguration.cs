using FCI.AlzheimerDetection.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.AlzheimerDetection.DAL.Configurations;

internal class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.ToTable("Medicines");

        builder.Property(m => m.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
           .HasMany(r => r.RelativeMedicine)
           .WithOne(r => r.Medicine)
           .HasForeignKey(r => r.MedicineId)
           .HasConstraintName("FK_Medicine_Relatives");
    }
}