using FCI.AlzheimerDetection.BL.DTOs.MRIDTOs;
using FCI.AlzheimerDetection.BL.DTOs.PatientDTOs;
using FCI.AlzheimerDetection.BL.Helper;
using FCI.AlzheimerDetection.BL.Managers.Abstractions;
using FCI.AlzheimerDetection.BL.Managers.Impelementations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FCI.AlzheimerDetection.BL.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services)
    {
        services.AddScoped<IPatientManager, PatientManager>();
        services.AddScoped<IAdminManager, AdminManager>();
        services.AddScoped<IRelativeManager, RelativeManager>();
        services.AddScoped<IAddRelativeManager, AddRelativeManager>();
        services.AddScoped<INormalUserManager, NormalUserManager>();
        services.AddScoped<IEmailManager, EmailManager>();
        services.AddScoped<IAdminMRIManager, AdminMRIManager>();
        services.AddScoped<INormalUserMRIManager, NormalUserMRIManager>();
        services.AddScoped<IMedicineManager, MedicineManager>();
        services.AddScoped<UserUtility>();
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()], includeInternalTypes: true);

        #region FluentValidation

        services.AddSingleton<IValidatorFactory, ServiceProviderValidatorFactory>(serviceProvider => new ServiceProviderValidatorFactory(serviceProvider));

        services.AddTransient<IValidator<CreatePatientDTO>, CreatePatientDTOValidator>();
        services.AddTransient<IValidator<UpdatePatientDTO>, UpdatePatientDTOValidator>();
        services.AddTransient<IValidator<UploadAdminMRIDTO>, UploadAdminMRIDTOValidator>();
        services.AddTransient<IValidator<UploadNormalUserMRI>, UploadNormalUserMRIValidator>();
        services.AddTransient<IValidator<UploadMultipleMRIDTO>, UploadMultipleMRIDTOValidator>();

        #endregion FluentValidation

        return services;
    }
}