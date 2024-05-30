using System.Globalization;
using TravelSample.Application.Hotels;
using TravelSample.Application.Models.SearchHotels;
using TravelSample.Domain.Entities;

namespace TravelSample.Services;

public class HotelUi(IHotelLogic hotelLogic) : IHotelUi
{
    private string _city;
    private DateTime _checkIn;
    
    public async Task Run()
    {
        var rule = new Rule("[yellow]Hotel[/]");
        rule.LeftJustified();
        AnsiConsole.Write(rule);

        CollectHotelData();
        var searchHotelRequest = new SearchHotelRequest(_city.ToUpper(), _checkIn, 1);

        AnsiConsole.Write("Searching flights...");

        var hotelResponse = await hotelLogic.Search(searchHotelRequest);
        if (hotelResponse.IsFailure)
        {
            Console.WriteLine();
            AnsiConsole.Write(new Markup(hotelResponse.Error!.Message, new Style(foreground: Color.Red)));
            Console.ReadKey();
            return;
        }
        
        Console.WriteLine();
        DrawHotels(hotelResponse.Value!);
        
        Console.WriteLine();
        AnsiConsole.Write("Press any key to return to the main menu.");
        Console.ReadKey();
    }
    
    private void CollectHotelData()
    {
        _city = AnsiConsole.Ask<string>("Enter city 3 ISO code (PAR):");
        _checkIn = AnsiConsole.Ask<DateTime>($"Enter check-in date ({DateTime.Now:yyyy-MM-dd}):");
    }
    
    private static void DrawHotels(List<Hotel> hotels)
    {
        var table = new Table();
        table.AddColumn(new TableColumn("Name").Centered());
        table.AddColumn(new TableColumn("Availability").Centered());
        table.AddColumn(new TableColumn("Address").Centered());
        table.AddColumn(new TableColumn("Rating").Centered());
        table.AddColumn(new TableColumn("Price").Centered());

        foreach (var hotel in hotels)
        {
            table.AddRow(
                hotel.Name, 
                hotel.Availability.ToString(), 
                hotel.Address, 
                hotel.Rating.ToString(CultureInfo.InvariantCulture),
                hotel.Price.ToString(CultureInfo.InvariantCulture));
        }

        AnsiConsole.Write(table);
    }
}