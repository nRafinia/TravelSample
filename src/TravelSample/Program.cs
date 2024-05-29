// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelSample.Application.Flights;
using TravelSample.Application.Models.SearchFlights;

var serviceCollection = new ServiceCollection()
    .AddLogging();

const string environmentName =
#if DEBUG
        "Development"
#else
    string.Empty
#endif
    ;
    
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

var flightService=serviceProvider.GetService<IFlightLogic>();
var a = await flightService.Search(new SearchFlightRequest("ATL", "CUN", DateTime.Now, DateTime.Now.AddDays(1)));

Console.WriteLine("Hello, World!");