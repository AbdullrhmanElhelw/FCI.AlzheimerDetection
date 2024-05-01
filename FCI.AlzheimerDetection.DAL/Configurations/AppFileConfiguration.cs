using FCI.AlzheimerDetection.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.AlzheimerDetection.DAL.Configurations;

internal class AppFileConfiguration : IEntityTypeConfiguration<AppFile>
{
    public void Configure(EntityTypeBuilder<AppFile> builder)
    {
        builder.ToTable("Files");

        builder.UseTptMappingStrategy();
    }
}