using FluentValidation;

namespace TravelSample.Application.Models.SearchFlights;

public class SearchFlightRequestValidation : AbstractValidator<SearchFlightRequest>
{
    public SearchFlightRequestValidation()
    {
        RuleFor(f => f.Origin).NotEmpty().Length(3);
        RuleFor(f => f.Destination).NotEmpty().Length(3);
        RuleFor(f => f.DepartureDate).GreaterThanOrEqualTo(DateTime.Now.Date);
        RuleFor(f => f.ReturnDate).GreaterThanOrEqualTo(DateTime.Now.Date);
    }
}