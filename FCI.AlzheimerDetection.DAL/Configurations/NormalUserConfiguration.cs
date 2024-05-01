using FCI.AlzheimerDetection.DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.AlzheimerDetection.DAL.Configurations;

internal class NormalUserConfiguration : IEntityTypeConfiguration<NormalUser>
{
    public void Configure(EntityTypeBuilder<NormalUser> builder)
    {
        builder.ToTable("NormalUsers");

        builder
            .HasMany(n => n.NormalUserMRIs)
            .WithOne(n => n.NormalUser)
            .HasForeignKey(n => n.NormalUserId)
            .HasConstraintName("FK_NormalUser_NormalUserMRIs");
    }
}