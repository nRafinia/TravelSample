using TravelSample.Application.Extensions;
using TravelSample.Application.Models.SearchFlights;
using TravelSample.Domain.Abstractions;

namespace TravelSample.Application.Flights;

public class FlightLogic(ITravelService travelService) : IFlightLogic
{
    public async Task<Result<List<Flight>?>> Search(SearchFlightRequest request)
    {
        var validator = new SearchFlightRequestValidation();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return Result.Failure<List<Flight>>(validationResult.Errors.ToError());
        }

        var searchResponse= await travelService.SearchFlightsAsync(
            request.Origin, 
            request.Destination, 
            request.DepartureDate,
            request.ReturnDate);
        
        return searchResponse.IsFailure 
            ? Result.Failure<List<Flight>>(searchResponse.Error!) 
            : searchResponse.Value;
    }
}