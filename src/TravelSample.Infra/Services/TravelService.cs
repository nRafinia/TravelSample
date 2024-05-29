using System.Globalization;
using Refit;
using TravelSample.Domain.Abstractions;
using TravelSample.Domain.Base.Results;
using TravelSample.Domain.Entities;
using TravelSample.Domain.Errors;
using TravelSample.Infra.Providers;

namespace TravelSample.Infra.Services;

public class TravelService(ISabreService sabreService/*, IAmadeusService amadeusService*/) : ITravelService
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
                var flightSegment = pricedItinerary.AirItinerary.OriginDestinationOptions.OriginDestinationOption.First().FlightSegments;

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

    public Task<Result<List<Hotel>?>> SearchHotelAsync(string city, DateTime checkIn, int rooms)
    {
        throw new NotImplementedException();
    }
}