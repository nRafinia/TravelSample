using TravelSample.Domain.Base;

namespace TravelSample.Domain.Errors;

public static class SharedErrors
{
    public static readonly Error RequestInvalid = new Error("Request.Invalid", "Request is invalid");
    public static Error RequestInvalidWithMessage(string message) => new Error("Request.Invalid", message);

    public static Error ProviderError(string errorMessage) =>
        new Error("Provider.Error", $"Provider error={errorMessage}");
    
    public static Error UnhandledError(string errorMessage) =>
        new Error("Internal.Error", $"Unhandled error={errorMessage}");
}