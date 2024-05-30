using System.Globalization;
using Refit;
using TravelSample.Domain.Abstractions;
using TravelSample.Domain.Base.Results;
using TravelSample.Domain.Entities;
using TravelSample.Domain.Errors;
using TravelSample.Infra.Models.Amadeus;
using TravelSample.Infra.Providers;
using Hotel = TravelSample.Domain.Entities.Hotel;

namespace TravelSample.Infra.Services;

public class TravelService(ISabreService sabreService, IAmadeusService amadeusService) : ITravelService
{
    public async Task<Result<List<Flight>?>> SearchFlightsAsync(string origin, string destination,
        DateTime departureDate, DateTime returnDate)
    {
        try
        {
            var searchResponse = await sabreService.SearchFlight(
                origin,
                destination,
                departureDate.ToString("yyyy-MM-dd"),
                returnDate.ToString("yyyy-MM-dd"));

            var response = new List<Flight>();
            foreach (var pricedItinerary in searchResponse.PricedItineraries)
            {
                var flightSegment = pricedItinerary.AirItinerary.OriginDestinationOptions.OriginDestinationOption
                    .First().FlightSegments;

                var flight = new Flight(
                    pricedItinerary.TpaExtensions.ValidatingCarrier.Code,
                    flightSegment.First().FlightNumber,
                    flightSegment.First().DepartureDateTime.ToString(CultureInfo.InvariantCulture),
                    flightSegment.First().ArrivalDateTime.ToString(CultureInfo.InvariantCulture),
                    pricedItinerary.AirItineraryPricingInfo.ItinTotalFare.TotalFare.Amount
                );

                response.Add(flight);
            }

            return response;
        }
        catch (ApiException e)
        {
            return Result.Failure<List<Flight>>(SharedErrors.ProviderError(e.Content ?? string.Empty));
        }
        catch (Exception e)
        {
            return Result.Failure<List<Flight>>(SharedErrors.UnhandledError(e.Message));
        }
    }

    public async Task<Result<List<Hotel>?>> SearchHotelAsync(string city, DateTime checkIn, int rooms)
    {
        try
        {
            var searchResponse = await amadeusService.SearchHotelByCity(city);

            var response = new List<Hotel>();
            foreach (var hotelData in searchResponse.Data.Chunk(20))
            {
                Hotel hotel;
                try
                {
                    var detailResponse = await amadeusService.GetHotelsData(
                        hotelData.Select(h => h.HotelId).ToArray(),
                        rooms,
                        checkIn.ToString("yyyy-MM-dd"));

                    foreach (var detail in detailResponse.Data)
                    {
                        var searchHotel = searchResponse.Data.First(x => x.HotelId == detail.Hotel.HotelId);

                        hotel = new Hotel(
                            detail.Hotel.Name,
                            detail.Available,
                            searchHotel.Address.CountryCode,
                            0,
                            detail.Offers.First().Price.Total);
                        response.Add(hotel);
                    }
                }
                catch
                {
                    //hotel = new Hotel(hotelData.Name, false, string.Empty, 0, 0);
                }


                await Task.Delay(100);
            }

            return response;
        }
        catch (ApiException e)
        {
            return Result.Failure<List<Hotel>>(SharedErrors.ProviderError(e.Content ?? string.Empty));
        }
        catch (Exception e)
        {
            return Result.Failure<List<Hotel>>(SharedErrors.UnhandledError(e.Message));
        }
    }
}