namespace TravelSample.Infra.Models.Amadeus;

public class HotelDetailData
{
    public Hotel Hotel { get; set; }
    public bool Available { get; set; }
    public List<Offer> Offers { get; set; }
}