using Application.Interfaces;
using EventStore.Store;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventStore.Extension;

public static class ServiceRegistrationExtension
{
    public static IServiceCollection AddEventLogService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EventLogSettings>(configuration.GetSection("EventLogSettings"));
        services.AddSingleton<IEventStore, Store.EventStore>();
        return services;
    }
}