using Refit;
using TravelSample.Infra.Models.Amadeus;

namespace TravelSample.Infra.Providers;

public interface IAmadeusService
{
    [Get("/v1/reference-data/locations/hotels/by-city?cityCode={cityCode}&radius=1&radiusUnit=KM&hotelSource=ALL")]
    Task<CityHotelResponse> SearchHotelByCity(string cityCode);
    
    [Get("/v3/shopping/hotel-offers?adults={adults}&checkInDate={checkInDate}")]
    Task<HotelsDataResponse> GetHotelsData([Query(CollectionFormat.Csv)]string[] hotelIds, int adults, string checkInDate);
}