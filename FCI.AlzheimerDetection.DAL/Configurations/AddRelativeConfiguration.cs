using FCI.AlzheimerDetection.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.AlzheimerDetection.DAL.Configurations;

internal class AddRelativeConfiguration : IEntityTypeConfiguration<AddRelative>
{
    public void Configure(EntityTypeBuilder<AddRelative> builder)
    {
        builder.HasKey(a => new { a.RelativeId, a.AdminId, a.PatientId });
    }
}