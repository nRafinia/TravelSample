using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using TravelSample.Infra.Extensions;
using TravelSample.Infra.Models.Configurations;

namespace TravelSample.Infra.Handler;

public class SabreTokenAuthenticationHandler(IOptions<SabreConfiguration> options) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var userIdEncode = options.Value.ApiUserId.ToBase64();
        var passwordEncode = options.Value.ApiPassword.ToBase64();
        var credentials = $"{userIdEncode}:{passwordEncode}".ToBase64();

        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        request.Content = new FormUrlEncodedContent([]);
        request.Headers.Add("grant_type", "client_credentials");

        return await base.SendAsync(request, cancellationToken);
    }
}