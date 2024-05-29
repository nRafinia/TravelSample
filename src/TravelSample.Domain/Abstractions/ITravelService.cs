using TravelSample.Domain.Base.Results;
using TravelSample.Domain.Entities;

namespace TravelSample.Domain.Abstractions;

public interface ITravelService
{
    Task<Result<List<Flight>?>> SearchFlightsAsync(string from, string to, DateTime departureDate, DateTime returnDate);
    Task<Result<List<Hotel>?>> SearchHotelAsync(string city, DateTime checkIn, int rooms);
}