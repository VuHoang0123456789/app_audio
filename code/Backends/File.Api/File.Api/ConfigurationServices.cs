using File.Application;
using File.Infrastructure;
using MediatR;
using Microsoft.OpenApi.Models;
using SharedKernel.Api;
using System.Reflection;

namespace File.Api;

public static class ConfigurationServices
{
    public static IServiceCollection AddFileApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectingStr = configuration.GetConnectionString("default");
        services.AddSharedKernelApiServices();
        services.AddFileApplicationServices(configuration);
        services.AddFileInfrastuctureServices(connectingStr);
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddControllers();
        services.AddCors(builder =>
        {
            builder.AddDefaultPolicy(options =>
            {
                options.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
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
        return services;
    }
}
