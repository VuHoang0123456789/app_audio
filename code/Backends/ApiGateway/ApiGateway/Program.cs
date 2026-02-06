using ApiGateway;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using NLog.Web;
using Ocelot.Middleware;
using Z.EntityFramework.Plus;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var services = builder.Services;
    services.AddApiGatewayServices(builder.Configuration);
    services.AddAuthenticationServices(builder.Configuration);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var CacheOptions = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMinutes(15) };
    QueryCacheManager.DefaultMemoryCacheEntryOptions = CacheOptions;

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
    //{
    //    app.UseSwaggerForOcelotUI();
    //}
    app.UseSwaggerForOcelotUI();

    app.UseCors();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseOcelot().Wait();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}


