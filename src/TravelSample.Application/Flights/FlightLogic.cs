using TravelSample.Application.Models.SearchFlights;
using TravelSample.Domain.Abstractions;
using TravelSample.Domain.Errors;

namespace TravelSample.Application.Flights;

public class FlightLogic(ITravelService travelService) : IFlightLogic
{
    public async Task<Result<List<Flight>?>> Search(SearchFlightRequest request)
    {
        var validator = new SearchFlightRequestValidation();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return Result.Failure<List<Flight>>(SharedErrors.RequestInvalid);
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