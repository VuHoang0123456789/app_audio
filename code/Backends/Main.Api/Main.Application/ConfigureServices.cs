using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Application;
using System.Reflection;

namespace Main.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddMainApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSharedKernelApplicationServices(configuration);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
