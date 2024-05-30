using FluentValidation;

namespace TravelSample.Application.Models.SearchHotels;

public class SearchHotelRequestValidation : AbstractValidator<SearchHotelRequest>
{
    public SearchHotelRequestValidation()
    {
        RuleFor(f => f.City).NotEmpty().Length(3);
        RuleFor(f => f.CheckIn).GreaterThanOrEqualTo(DateTime.Now.Date);
        RuleFor(f => f.Rooms).GreaterThan(0);
    }
}