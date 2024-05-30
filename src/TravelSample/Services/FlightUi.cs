using TravelSample.Application.Flights;

namespace TravelSample.Services;

public class FlightUi(IFlightLogic flightLogic) : IFlightUi
{
    public async Task Run()
    {
        var rule = new Rule("[yellow]Flight[/]");
        rule.LeftJustified();
        AnsiConsole.Write(rule);
    }
}