namespace TravelSample.Infra.Handler;

public class SabreAuthenticationHandler:DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        
        return await base.SendAsync(request, cancellationToken);
    }
}