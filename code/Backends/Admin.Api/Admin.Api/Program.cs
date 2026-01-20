using Admin.Api;
using Admin.Infrastructure.Data;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    IServiceCollection services = builder.Services;
    services.AddAddminApiServices(builder.Configuration);

    var app = builder.Build();

    using (var scoped = app.Services.CreateScope())
    {
        AdminContextInitial adminDbContext = scoped.ServiceProvider.GetRequiredService<AdminContextInitial>();
        await adminDbContext.InitialiseAsync();
        await adminDbContext.SeedAsync();
    }

    if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers(); 

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex, "topped program because of exception");
    throw;
}

