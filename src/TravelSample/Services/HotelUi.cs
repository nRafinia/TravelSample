using TravelSample.Application.Hotels;

namespace TravelSample.Services;

public class HotelUi(IHotelLogic hotelLogic) : IHotelUi
{
    public async Task Run()
    {
        var rule = new Rule("[yellow]Hotel[/]");
        rule.LeftJustified();
        AnsiConsole.Write(rule);
    }
}