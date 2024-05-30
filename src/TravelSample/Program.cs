using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelSample.Services;

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

var runnerService=serviceProvider.GetService<IRunner>();
await runnerService!.Run();
