using ApiGateway.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Ocelot.DependencyInjection;

namespace ApiGateway;

public static class ConfigureServices
{
    public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
    {
        string AuthorityStr = configuration.GetValue<string>("Authority");

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.Authority = AuthorityStr;
                options.BackchannelHttpHandler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = delegate { return true; }
                };
                options.TokenValidationParameters.ValidateAudience = false;
                options.TokenValidationParameters.ValidateIssuer = false;
                options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
                options.SaveToken = true;
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        var payload = new JObject
                        {
                            ["error"] = context.Error,
                            ["error_description"] = context.ErrorDescription,
                            ["error_uri"] = context.ErrorUri
                        };

                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";

                        return context.Response.WriteAsync(payload.ToString());
                    }
                };
            })
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);
        return services;
    }

    public static IServiceCollection AddApiGatewayServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectStringStr = configuration.GetConnectionString("default");
        services.AddDbContext<IdentityContext>(builder =>
        {
            builder.UseSqlServer(connectStringStr);
        });
        //services.AddEndpointsApiExplorer();
        //services.AddSwaggerGen();
        services.AddCors(builder =>
        {
            builder.AddDefaultPolicy(options =>
            {
                options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });

        IConfiguration configurationOcelot = new ConfigurationBuilder()
            .AddJsonFile("ocelot.json")
            .AddJsonFile("ocelot.swagger.json")
            .Build();  

        services.AddOcelot(configurationOcelot);
        services.AddSwaggerForOcelot(configurationOcelot);

        return services;
    }
}
