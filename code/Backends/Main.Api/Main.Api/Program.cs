using Main.Api;
using Main.Infrastructure.Data;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    #region Add services to the container.
    var services = builder.Services;
    services.AddMainServices(builder.Configuration);
    #endregion

    //clear logging providers default
    builder.Logging.ClearProviders();

    //use NLog is logging providers
    builder.Host.UseNLog();

    var app = builder.Build();

    using (var scoped = app.Services.CreateScope())
    {
        MainDbContextInitial mainDbContext = scoped.ServiceProvider.GetRequiredService<MainDbContextInitial>();
       await mainDbContext.InitialiseAsync();
       await mainDbContext.SeedAsync();
    }

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}


