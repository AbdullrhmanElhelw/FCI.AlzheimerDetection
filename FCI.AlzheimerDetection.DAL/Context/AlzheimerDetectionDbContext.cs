using FCI.AlzheimerDetection.DAL.Models;
using FCI.AlzheimerDetection.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace FCI.AlzheimerDetection.DAL.Context;

public class AlzheimerDetectionDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public AlzheimerDetectionDbContext(DbContextOptions<AlzheimerDetectionDbContext> options) : base(options)
    {
        try
        {
            if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
            {
                if (!(databaseCreator.CanConnect()))
                {
                    databaseCreator.CreateTables();
                }
                if (!databaseCreator.HasTables())
                {
                    databaseCreator.CreateTables();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Relative> Relatives => Set<Relative>();
    public DbSet<NormalUser> NormalUsers => Set<NormalUser>();

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<AppFile> Files => Set<AppFile>();
    public DbSet<MRI> MRIs => Set<MRI>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<Medicine> Medicines => Set<Medicine>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}