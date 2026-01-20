using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Application;
using System.Reflection;

namespace Admin.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddAdminApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSharedKernelApplicationServices(configuration);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidation(new [] {Assembly.GetExecutingAssembly()});
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);
        return services;
    }
}
