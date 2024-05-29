using System.Net.Http.Headers;
using TravelSample.Infra.Providers;

namespace TravelSample.Infra.Handler;

public class SabreAuthenticationHandler(ISabreTokenService tokenService)
    : DelegatingHandler
{
    private static KeyValuePair<DateTime, string> _token = new(DateTime.MinValue, string.Empty);

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await GetToken();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }

    private async Task<string> GetToken()
    {
        if (DateTime.Now < _token.Key)
        {
            return _token.Value;
        }

        var tokenResponse = await tokenService.GetToken();
        _token = new KeyValuePair<DateTime, string>(
            DateTime.Now.AddSeconds(tokenResponse.ExpiresIn),
            tokenResponse.Token);

        return _token.Value;
    }
}