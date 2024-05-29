using System.Text.Json.Serialization;

namespace TravelSample.Infra.Models.Sabre;

public class OriginDestinationOption
{
    [JsonPropertyName("FlightSegment")]
    public List<FlightSegment> FlightSegments { get; set; }
}