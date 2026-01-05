using Main.Application;
using Main.Infrastructure;
using Microsoft.OpenApi.Models;
using SharedKernel.Api;

namespace Main.Api
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddMainServices(this IServiceCollection services, IConfiguration configuration) {
            string? connectionStr = configuration.GetConnectionString("default");
            services.AddSharedKernelApiServices();
            services.AddMainApplicationServices(configuration);
            services.AddMainInfrastructureServices(connectionStr);
            services.AddControllers();
            services.AddCors((options) =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhot:3000") //Chỉ định các client dc phép truy cập
                    .AllowAnyMethod() //chỉ định các phương thức http được phép dùng (GET, POST, PUT, DELETE, etc.)
                    .AllowAnyHeader(); //chỉ định các header được cho phép
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

            services.AddMemoryCache();
            return services;
        }
    }
}
