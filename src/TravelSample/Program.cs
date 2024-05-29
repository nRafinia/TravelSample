// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection()
    .AddLogging();

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();

TravelSample.Application.ConfigureServices.Register(serviceCollection, configuration);
TravelSample.Infra.ConfigureServices.Register(serviceCollection, configuration);
TravelSample.ConfigureServices.Register(serviceCollection, configuration);

var serviceProvider = serviceCollection
    .BuildServiceProvider();

Console.WriteLine("Hello, World!");