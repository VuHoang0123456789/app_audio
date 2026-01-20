using Admin.Domain.Interfaces;
using Admin.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure;
using System.Reflection;

namespace Admin.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddAdminInfratureServicers(this IServiceCollection services, string connectionStr)
    {
        services.AddSharedKernelInfrastructureServices();
        services.AddDbContext<AdminContext>(builder => builder.UseSqlServer(connectionStr, sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));
        services.AddScoped<IAdminContext>(provider => provider.GetRequiredService<AdminContext>());
        services.AddScoped<AdminContextInitial>();
        return services;
    }
}
