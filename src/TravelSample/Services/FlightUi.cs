using System.Globalization;
using TravelSample.Application.Flights;
using TravelSample.Application.Models.SearchFlights;
using TravelSample.Domain.Entities;

namespace TravelSample.Services;

public class FlightUi(IFlightLogic flightLogic) : IFlightUi
{
    private string _origin;
    private string _destination;
    private DateTime _departureDate;
    private DateTime _returnDate;

    public async Task Run()
    {
        var rule = new Rule("[yellow]Flight[/]");
        rule.LeftJustified();
        AnsiConsole.Write(rule);

        CollectFlightData();
        var searchFlightRequest = new SearchFlightRequest(_origin.ToUpper(), _destination.ToUpper(), _departureDate, _returnDate);

        AnsiConsole.Write("Searching flights...");

        var flightResponse = await flightLogic.Search(searchFlightRequest);
        if (flightResponse.IsFailure)
        {
            Console.WriteLine();
            AnsiConsole.Write(new Markup(flightResponse.Error!.Message, new Style(foreground: Color.Red)));
            Console.ReadKey();
            return;
        }
        
        Console.WriteLine();
        DrawFlights(flightResponse.Value!);
        
        Console.WriteLine();
        AnsiConsole.Write("Press any key to return to the main menu.");
        Console.ReadKey();
    }

    private void CollectFlightData()
    {
        _origin = AnsiConsole.Ask<string>("Enter origin IATA airport code (ATL):");
        _destination = AnsiConsole.Ask<string>("Enter destination IATA airport code (CUN):");
        _departureDate = AnsiConsole.Ask<DateTime>($"Enter departure date ({DateTime.Now:yyyy-MM-dd}):");
        _returnDate = AnsiConsole.Ask<DateTime>($"Enter return date ({DateTime.Now:yyyy-MM-dd}):");
    }
    
    private static void DrawFlights(List<Flight> flights)
    {
        var table = new Table();
        table.AddColumn(new TableColumn("Flight").Centered());
        table.AddColumn(new TableColumn("Departure").Centered());
        table.AddColumn(new TableColumn("Arrival").Centered());
        table.AddColumn(new TableColumn("Price").Centered());

        foreach (var flight in flights)
        {
            table.AddRow(
                flight.FlightNumber.ToString(), 
                flight.DepartureTime, 
                flight.ArrivalTime, 
                flight.Price.ToString(CultureInfo.InvariantCulture));
        }

        AnsiConsole.Write(table);
    }
}