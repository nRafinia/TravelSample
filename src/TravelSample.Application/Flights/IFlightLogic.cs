using TravelSample.Application.Models.SearchFlights;

namespace TravelSample.Application.Flights;

public interface IFlightLogic
{
    Task<Result<List<Flight>?>> Search(SearchFlightRequest request);
}