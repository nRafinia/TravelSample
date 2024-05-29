using Refit;
using TravelSample.Infra.Models.Sabre;

namespace TravelSample.Infra.Providers;

public interface ISabreService
{
    [Get("/v1/shop/flights?origin={origin}&destination={destination}&departuredate={departureDate}&returndate={returnDate}")]
    Task<FlightResponse> SearchFlight(string origin, string destination, string departureDate, string returnDate);
}