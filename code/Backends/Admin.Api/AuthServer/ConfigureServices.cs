using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Api;

namespace AuthServer;

public static class ConfigureServices
{
    public static IServiceCollection AddIdentityServerServices(this IServiceCollection services, IConfiguration configuration)
    {
        //add services DataProtection
        string connectStringStr = configuration.GetConnectionString("Default");
        services.AddDbContext<DataProtectionKeysContext>(options =>
        {
            options.UseSqlServer(connectStringStr);
        });

         services.AddDataProtection()
        .PersistKeysToDbContext<DataProtectionKeysContext>()
        .SetApplicationName("AuthServer");

        // Add services to the container.
        services.AddControllersWithViews();
        services.AddSharedKernelApiServices();
        return services;
    }
}
