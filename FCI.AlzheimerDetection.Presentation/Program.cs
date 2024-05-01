using FCI.AlzheimerDetection.BL.DependencyInjection;
using FCI.AlzheimerDetection.BL.Enums;
using FCI.AlzheimerDetection.DAL;
using FCI.AlzheimerDetection.DAL.Context;
using FCI.AlzheimerDetection.DAL.Models.Identity;
using FCI.AlzheimerDetection.DAL.Settings.EmailSettings;
using FCI.AlzheimerDetection.DAL.Settings.TokenSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AlzAware", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

#endregion Swagger

#region Services

builder.Services
    .AddDataAccessLayerDependencies(builder.Configuration)
    .AddBusinessLogicDependencies()
    .AddMigrate();

#endregion Services

#region Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
    .AddEntityFrameworkStores<AlzheimerDetectionDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Admin>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AlzheimerDetectionDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Relative>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AlzheimerDetectionDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<NormalUser>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AlzheimerDetectionDbContext>()
    .AddDefaultTokenProviders();

#endregion Identity

#region BearerDefaultAuthentecation

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Default";
    options.DefaultChallengeScheme = "Default";
}
)
    .AddJwtBearer("Default", options =>
    {
        var jwtsettings = builder.Configuration.GetSection("JWTSetting").Get<JWTSetting>()
        ?? throw new Exception("No JWTSetting Section is Exists in AppConfiguration File ");
        var getKey = Encoding.UTF8.GetBytes(jwtsettings.Key);
        var key = new SymmetricSecurityKey(getKey);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtsettings.Issuer,
            ValidAudience = jwtsettings.Audicne,
            IssuerSigningKey = key
        };
    });

#endregion BearerDefaultAuthentecation

#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(nameof(AppRoles.Admin), policy => policy.RequireRole(nameof(AppRoles.Admin)));
    options.AddPolicy(nameof(AppRoles.Relative), policy => policy.RequireRole(nameof(AppRoles.Relative)));
    options.AddPolicy(nameof(AppRoles.NormalUser), policy => policy.RequireRole(nameof(AppRoles.NormalUser)));
});

#endregion Authorization

#region Settings

builder.Services.Configure<JWTSetting>(builder.Configuration.GetSection("JWTSetting"));
builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSetting"));

#endregion Settings

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FCI.AlzheimerDetection.Presentation v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();