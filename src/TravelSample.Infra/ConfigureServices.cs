

// ReSharper disable InconsistentNaming

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TravelSample.Infra;

public static class ConfigureServices
{
    //private const string WHMCSConfigurationName = nameof(WHMCSConfiguration);

    public static void Register(IServiceCollection services, IConfiguration configuration)
    {

        
        AddRefitServices(services, configuration);
    }

    private static void AddRefitServices(IServiceCollection services, IConfiguration configuration)
    {
        /*var config = configuration.RegisterAndGetConfiguration<WHMCSConfiguration>(services, WHMCSConfigurationName);

        services.AddScoped<SentryHttpMessageHandler>();
        services.AddScoped<CollectionIndexerUrlHandler>();
        
        services
            .AddRefitClient<IRequestService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(config.Server))
            .AddHttpMessageHandler<CollectionIndexerUrlHandler>()
            .AddHttpMessageHandler<SentryHttpMessageHandler>();*/
    }
}