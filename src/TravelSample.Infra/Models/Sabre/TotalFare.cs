namespace TravelSample.Infra.Models.Sabre;

public class TotalFare
{
    public string CurrencyCode { get; set; }
    public int DecimalPlaces { get; set; }
    public decimal Amount { get; set; }
}