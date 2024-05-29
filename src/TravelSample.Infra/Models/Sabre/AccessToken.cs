using System.Text.Json.Serialization;

namespace TravelSample.Infra.Models.Sabre;

public class AccessToken
{
    [JsonPropertyName("access_token")]
    public string Token { get; set; }

    [JsonPropertyName("token_type")]
    public string Type { get; set; }
    
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
}