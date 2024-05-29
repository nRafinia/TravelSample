using Refit;
using TravelSample.Infra.Models.Amadeus;

namespace TravelSample.Infra.Providers;

public interface IAmadeusTokenService
{
    [Get("/v1/security/oauth2/token")]
    Task<AccessToken> GetToken();
}