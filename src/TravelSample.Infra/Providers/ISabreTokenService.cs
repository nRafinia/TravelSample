using Refit;
using TravelSample.Infra.Models.Sabre;

namespace TravelSample.Infra.Providers;

public interface ISabreTokenService
{
    [Post("/v2/auth/token")]
    Task<AccessToken> GetToken();
}