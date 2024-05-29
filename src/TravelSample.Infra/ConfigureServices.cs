// ReSharper disable InconsistentNaming

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using TravelSample.Domain.Abstractions;
using TravelSample.Infra.Extensions;
using TravelSample.Infra.Handler;
using TravelSample.Infra.Models.Configurations;
using TravelSample.Infra.Providers;
using TravelSample.Infra.Services;

namespace TravelSample.Infra;

public static class ConfigureServices
{
    private const string SabreConfigurationName = nameof(SabreConfiguration);
    private const string AmadeusConfigurationName = nameof(AmadeusConfiguration);

    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITravelService, TravelService>();

        AddRefitServices(services, configuration);
    }

    private static void AddRefitServices(IServiceCollection services, IConfiguration configuration)
    {
        AddSabreRefitService(services, configuration);
        AddAmadeusRefitService(services, configuration);
    }

    private static void AddSabreRefitService(IServiceCollection services, IConfiguration configuration)
    {
        var sabreConfiguration =
            configuration.RegisterAndGetConfiguration<SabreConfiguration>(services, SabreConfigurationName);

        services
            .AddRefitClient<ISabreTokenService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(sabreConfiguration.Domain))
            .AddHttpMessageHandler<SabreTokenAuthenticationHandler>();

        services
            .AddRefitClient<ISabreService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(sabreConfiguration.Domain))
            .AddHttpMessageHandler<SabreAuthenticationHandler>();
    }

    private static void AddAmadeusRefitService(IServiceCollection services, IConfiguration configuration)
    {
        var amadeusConfiguration =
            configuration.RegisterAndGetConfiguration<AmadeusConfiguration>(services, AmadeusConfigurationName);

        services
            .AddRefitClient<IAmadeusTokenService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(amadeusConfiguration.Domain))
            .AddHttpMessageHandler<AmadeusTokenAuthenticationHandler>();

        services
            .AddRefitClient<IAmadeusService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(amadeusConfiguration.Domain))
            .AddHttpMessageHandler<AmadeusAuthenticationHandler>();
    }
}