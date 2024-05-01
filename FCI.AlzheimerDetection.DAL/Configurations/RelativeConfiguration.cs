using FCI.AlzheimerDetection.DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.AlzheimerDetection.DAL.Configurations;

internal class RelativeConfiguration : IEntityTypeConfiguration<Relative>
{
    public void Configure(EntityTypeBuilder<Relative> builder)
    {
        builder.ToTable("Relatives");

        builder.Property(r => r.SSN)
           .HasMaxLength(14)
           .IsRequired();

        builder.Property(r => r.City)
             .HasMaxLength(50)
             .IsRequired();

        builder.Property(r => r.Street)
           .HasMaxLength(100)
           .IsRequired();

        builder.Property(r => r.ZipCode)
            .HasMaxLength(10)
            .IsRequired(false);

        builder.Property(r => r.BirthDate)
            .IsRequired();

        builder
            .HasMany(r => r.RelativeMedicine)
            .WithOne(r => r.Relative)
            .HasForeignKey(r => r.RelativeId)
            .HasConstraintName("FK_Relative_Medicines");

        builder
           .HasMany(a => a.AddRelatives)
           .WithOne(a => a.Relative)
           .HasForeignKey(a => a.RelativeId)
           .HasConstraintName("FK_Relative_AddRelatives");
    }
}