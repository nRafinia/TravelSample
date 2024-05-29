using Microsoft.Extensions.Options;
using TravelSample.Infra.Models.Configurations;

namespace TravelSample.Infra.Handler;

public class AmadeusTokenAuthenticationHandler(IOptions<AmadeusConfiguration> options) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var formData = new List<KeyValuePair<string, string>>()
        {
            new ("grant_type",$"client_credentials&client_id={options.Value.Key}&client_secret={options.Value.Secret}")
        };
        
        request.Content = new FormUrlEncodedContent(formData);

        return await base.SendAsync(request, cancellationToken);
    }
}