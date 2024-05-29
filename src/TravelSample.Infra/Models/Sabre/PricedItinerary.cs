using System.Text.Json.Serialization;

namespace TravelSample.Infra.Models.Sabre;

public class PricedItinerary
{
    public AirItinerary AirItinerary { get; set; }
    
    [JsonPropertyName("TPA_Extensions")]
    public TPAExtensions TpaExtensions { get; set; }

    public AirItineraryPricingInfo AirItineraryPricingInfo { get; set; }
}