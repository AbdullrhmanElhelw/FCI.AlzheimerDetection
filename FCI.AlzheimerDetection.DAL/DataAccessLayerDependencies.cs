using FCI.AlzheimerDetection.DAL.Context;
using FCI.AlzheimerDetection.DAL.TokenProviders;
using FCI.AlzheimerDetection.DAL.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FCI.AlzheimerDetection.DAL;

public static class DataAccessLayerDependencies
{
    public static IServiceCollection AddDataAccessLayerDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AlzheimerDetectionDbContext>(op =>
        {
            op.UseSqlServer(configuration.GetConnectionString("AlzAwareDb"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITokenProvider, JWTTokenProvider>();

        return services;
    }

    public static IServiceCollection AddMigrate(this IServiceCollection services)
    {
        using var scope = services
            .BuildServiceProvider()
            .CreateScope();

        var context = scope.ServiceProvider
            .GetRequiredService<AlzheimerDetectionDbContext>();

        context.Database.Migrate();
        return services;
    }
}