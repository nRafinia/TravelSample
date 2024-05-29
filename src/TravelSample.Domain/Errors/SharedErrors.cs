

using TravelSample.Domain.Base;

namespace TravelSample.Domain.Errors;

public static class SharedErrors
{
    public static readonly Error RequestInvalid = new Error("Request.Invalid", "Request is invalid");
}