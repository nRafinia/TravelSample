using TravelSample.Application.Models.SearchHotels;

namespace TravelSample.Application.Hotels;

public interface IHotelLogic
{
    Task<Result<List<Hotel>?>> Search(SearchHotelRequest request);
}