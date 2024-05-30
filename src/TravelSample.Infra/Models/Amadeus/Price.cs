using System.Text.Json.Serialization;

namespace TravelSample.Infra.Models.Amadeus;

public class Price
{
    [JsonPropertyName("total")]
    public string TotalText { get; set; }
    
    [JsonIgnore]
    public decimal Total => decimal.Parse(TotalText);
}