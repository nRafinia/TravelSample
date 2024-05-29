namespace TravelSample.Application.Models.SearchHotels;

public record SearchHotelRequest(string City, DateTime CheckIn, int Rooms);