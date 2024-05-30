using Refit;
using TravelSample.Infra.Models.Amadeus;

namespace TravelSample.Infra.Providers;

public interface IAmadeusTokenService
{
    [Headers("Content-Type: application/x-www-form-urlencoded")]
    [Post("/v1/security/oauth2/token")]
    Task<AccessToken> GetToken();
}