using FCI.AlzheimerDetection.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.AlzheimerDetection.DAL.Configurations;

internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");

        builder.Property(p => p.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.SSN)
           .HasMaxLength(14)
           .IsRequired();

        builder.Property(p => p.City)
             .HasMaxLength(50)
             .IsRequired();

        builder.Property(p => p.Street)
           .HasMaxLength(100)
           .IsRequired();

        builder.Property(p => p.ZipCode)
            .HasMaxLength(10)
            .IsRequired(false);

        builder.Property(p => p.BirthDate)
            .IsRequired();

        builder
            .HasOne(a => a.Image)
            .WithOne(a => a.Patient)
            .HasForeignKey<Image>(a => a.PatientId)
            .HasConstraintName("FK_Patient_Image");

        builder
           .HasMany(a => a.AddRelatives)
           .WithOne(a => a.Patient)
           .HasForeignKey(a => a.PatientId)
           .HasConstraintName("FK_Patient_AddRelatives");
    }
}