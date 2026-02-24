using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Api;

namespace AuthServer;

public static class ConfigureServices
{
    public static IServiceCollection AddIdentityServerServices(this IServiceCollection services, IConfiguration configuration)
    {
        //add services DataProtection
        string connectionStr = configuration.GetConnectionString("Default");
        services.AddDbContext<DataProtectionKeysContext>(options =>
        {
            options.UseSqlServer(connectionStr);
        });

         services.AddDataProtection()
        .PersistKeysToDbContext<DataProtectionKeysContext>()
        .SetApplicationName("AuthServer");
        //services.AddOidcStateDataFormatterCache();

        services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.ServerSideSessions.RemoveExpiredSessions = true;
            options.ServerSideSessions.ExpiredSessionsTriggerBackchannelLogout = true;
            options.KeyManagement.RotationInterval = TimeSpan.FromDays(736);
            options.KeyManagement.DeleteRetiredKeys = true;
        })
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = (builder => builder.UseSqlServer(connectionStr, sql => sql.MigrationsAssembly("Admin.Infrastructure")));
                options.DefaultSchema = "identity";
            })
            .AddConfigurationStoreCache()
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(connectionStr,
                    sql => sql.MigrationsAssembly("Admin.Infrastructure"));
                options.DefaultSchema = "identity";
                options.EnableTokenCleanup = true;
                options.RemoveConsumedTokens = true;
            })
            .AddServerSideSessions();

        // Add services to the container.
        services.AddControllersWithViews();
        services.AddSharedKernelApiServices();
        return services;
    }
}
