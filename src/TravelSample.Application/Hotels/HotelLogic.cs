using TravelSample.Application.Models.SearchHotels;
using TravelSample.Domain.Abstractions;
using TravelSample.Domain.Errors;

namespace TravelSample.Application.Hotels;

public class HotelLogic(ITravelService travelService) : IHotelLogic
{
    public async Task<Result<List<Hotel>?>> Search(SearchHotelRequest request)
    {
        var validator = new SearchHotelRequestValidation();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return Result.Failure<List<Hotel>>(SharedErrors.RequestInvalid);
        }

        var searchResponse= await travelService.SearchHotelAsync(
            request.City, 
            request.CheckIn, 
            request.Rooms);
        
        return searchResponse.IsFailure 
            ? Result.Failure<List<Hotel>>(searchResponse.Error!) 
            : searchResponse.Value;
    }
}