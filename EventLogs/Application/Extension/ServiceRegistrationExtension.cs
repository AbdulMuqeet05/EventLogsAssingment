using Application.BackgroundServices;
using Application.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
public static class ServiceRegistrationExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services , IConfiguration configuration)
    {
        services.Configure<BackgroundWorkerSettings>(configuration.GetSection("BackgroundWorkerSettings"));
        services.AddHostedService<LogGeneratorWorker>();
        // services.AddSingleton<LogGeneratorWorker>();
        return services;
    }
}