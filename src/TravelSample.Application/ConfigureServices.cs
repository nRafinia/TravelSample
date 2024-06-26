﻿// ReSharper disable InconsistentNaming

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelSample.Application.Flights;
using TravelSample.Application.Hotels;

namespace TravelSample.Application;

public static class ConfigureServices
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFlightLogic, FlightLogic>();
        services.AddScoped<IHotelLogic, HotelLogic>();
    }
}