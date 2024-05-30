namespace TravelSample.Services;

public class Runner(IFlightUi flightUi, IHotelUi hotelUi) : IRunner
{
    private const string SearchFlights = "Search Flights";
    private const string SearchHotels = "Search Hotels";
    private const string Exit = "Exit";

    public async Task Run()
    {
        var selectedMainMenu = string.Empty;
        while (selectedMainMenu != Exit)
        {
            AnsiConsole.Clear();
            
            selectedMainMenu = ShowMenuForSelect();
            switch (selectedMainMenu)
            {
                case SearchFlights:
                    await flightUi.Run();
                    break;
                
                case SearchHotels:
                    await hotelUi.Run();
                    break;
                
                case Exit:
                    break;
            }
        }

        Environment.Exit(0);

    }

    private string ShowMenuForSelect()
    {
        AnsiConsole.Write(
            new FigletText("Travel sample")
                .Centered()
                .Color(Color.Blue));

        var selectedMainMenu = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option")
                .PageSize(10)
                .AddChoices(
                [
                    SearchFlights,
                    SearchHotels,
                    Exit
                ])
        );

        return selectedMainMenu;
    }
}