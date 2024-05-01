using FCI.AlzheimerDetection.DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.AlzheimerDetection.DAL.Configurations;

internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admins");

        builder.Property(a => a.SSN)
            .HasMaxLength(14)
            .IsRequired();

        builder.Property(a => a.City)
             .HasMaxLength(50)
             .IsRequired();

        builder.Property(a => a.Street)
           .HasMaxLength(100)
           .IsRequired();

        builder.Property(a => a.ZipCode)
            .HasMaxLength(10)
            .IsRequired(false);

        builder.Property(a => a.BirthDate)
            .IsRequired();

        builder
            .HasMany(a => a.Patients)
            .WithOne(a => a.Admin)
            .HasForeignKey(a => a.AdminId)
            .HasConstraintName("FK_Admin_Patients");

        builder
            .HasMany(a => a.AdminMRIs)
            .WithOne(a => a.Admin)
            .HasForeignKey(a => a.AdminId)
            .HasConstraintName("FK_Admin_MRIs");

        builder
            .HasMany(a => a.Reports)
            .WithOne(a => a.Admin)
            .HasForeignKey(a => a.AdminId)
            .HasConstraintName("FK_Admin_Reports");

        builder
            .HasMany(a => a.Medicines)
            .WithOne(a => a.Admin)
            .HasForeignKey(a => a.AdminId)
            .HasConstraintName("FK_Admin_Medicines");

        builder
            .HasMany(a => a.AddRelatives)
            .WithOne(a => a.Admin)
            .HasForeignKey(a => a.AdminId)
            .HasConstraintName("FK_Admin_AddRelatives");
    }
}