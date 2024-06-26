﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TravelSample.Infra.Extensions;

internal static class ConfigurationExt
{
    public static T RegisterAndGetConfiguration<T>(this IConfiguration configuration, IServiceCollection services,
        string sectionName)
        where T : class, new()
    {
        var config = new T();
        var section = configuration.GetSection(sectionName);
        if (!section.Exists())
        {
            return config;
        }
        
        section.Bind(config);
        services.Configure<T>(section);

        return config;
    }
}