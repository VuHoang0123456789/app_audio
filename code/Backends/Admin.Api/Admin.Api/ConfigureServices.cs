using Admin.Application;
using Admin.Infrastructure;
using Microsoft.OpenApi.Models;
using SharedKernel.Api;

namespace Admin.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddAddminApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionStr = configuration.GetConnectionString("default");
        services.AddSharedKernelApiServices();
        services.AddAdminApplicationServices(configuration);
        services.AddAdminInfratureServicers(connectionStr);
        services.AddControllers();
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder => builder
                .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(d =>
        {
            d.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "Enter JWT token: Bearer {your token}"
            });

            d.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
        });

        services.AddMemoryCache();
        return services;
    }
}
