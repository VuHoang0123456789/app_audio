namespace Log.Api;

public static class ConfigureServices
{
    public static void AddLogApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
    }
}
