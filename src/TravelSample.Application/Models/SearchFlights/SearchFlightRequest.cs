namespace TravelSample.Application.Models.SearchFlights;

public record SearchFlightRequest(string Origin, string Destination, DateTime DepartureDate, DateTime ReturnDate);