using Main.Application.Interfaces;
using Main.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure;
using System.Reflection;

namespace Main.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddMainInfrastructureServices(this IServiceCollection services, string connectionStr)
    {
        services.AddSharedKernelInfrastructureServices();
        services.AddDbContext<MainDbContext>(
            (builder) => builder.UseSqlServer(connectionStr, sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName))
        );

        services.AddScoped<IMainDbContext>(provider => provider.GetRequiredService<MainDbContext>());
        services.AddScoped<MainDbContextInitial>();
        return services;
    }
}
