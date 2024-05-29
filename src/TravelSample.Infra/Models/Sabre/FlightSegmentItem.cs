using System.Globalization;
using System.Text.Json.Serialization;

namespace TravelSample.Infra.Models.Sabre;

public class FlightSegmentItem
{
    [JsonPropertyName("DepartureDateTime")]
    public string DepartureDateTimeText { get; set; }

    [JsonIgnore]
    public DateTime DepartureDateTime =>
        DateTime.ParseExact(DepartureDateTimeText, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

    [JsonPropertyName("ArrivalDateTime")] 
    public string ArrivalDateTimeText { get; set; }

    [JsonIgnore]
    public DateTime ArrivalDateTime =>
        DateTime.ParseExact(ArrivalDateTimeText, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

    public int FlightNumber { get; set; }
}