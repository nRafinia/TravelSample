

// ReSharper disable InconsistentNaming

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelSample.Services;

namespace TravelSample;

public static class ConfigureServices
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRunner, Runner>();
        services.AddScoped<IFlightUi, FlightUi>();
        services.AddScoped<IHotelUi, HotelUi>();
    }
}