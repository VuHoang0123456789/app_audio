using File.Application.Interfaces;
using File.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure;
using System.Reflection;

namespace File.Infrastructure;

public static class ConfigurationServices
{
    public static IServiceCollection AddFileInfrastuctureServices(this IServiceCollection services, string connectingSrt)
    {
        services.AddSharedKernelInfrastructureServices();
        services.AddDbContext<FileDbContext>(opstions => opstions.UseSqlServer(connectingSrt, sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));
        services.AddScoped<IFileDbContext>(provider => provider.GetRequiredService<FileDbContext>());
        services.AddScoped<FileDbContextInitial>();
        return services;
    }
}
