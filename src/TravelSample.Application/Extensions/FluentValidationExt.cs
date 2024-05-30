using FluentValidation.Results;
using TravelSample.Domain.Base;
using TravelSample.Domain.Errors;

namespace TravelSample.Application.Extensions;

public static class FluentValidationExt
{
    public static Error ToError(this List<ValidationFailure> failures)
    {
        var message = string.Join(Environment.NewLine, failures.Select(failure => $"{failure.PropertyName}={failure.ErrorMessage}"));
        return SharedErrors.RequestInvalidWithMessage(message);
    }
}