using TravelSample.Domain.Abstractions;
using TravelSample.Domain.Base.Results;
using TravelSample.Domain.Entities;

namespace TravelSample.Infra.Services;

public class TravelService : ITravelService
{
    public Task<Result<List<Flight>>> SearchFlightsAsync(string from, string to, DateTime departureDate, DateTime returnDate)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<Hotel>>> SearchHotelAsync(string city, DateTime checkIn, int rooms)
    {
        throw new NotImplementedException();
    }
}