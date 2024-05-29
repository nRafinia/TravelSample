using Ardalis.GuardClauses;

namespace TravelSample.Domain.Entities;

public class Hotel(string name, bool availability, string address, float rating, decimal price)
{
    public string Name { get; init; } = Guard.Against.NullOrEmpty(name, nameof(name));
    public bool Availability { get; init; } = availability;
    public string Address { get; init; } = Guard.Against.NullOrEmpty(address, nameof(address));
    public float Rating { get; init; } = Guard.Against.Zero(rating, nameof(rating));
    public decimal Price { get; init; } = Guard.Against.Zero(price, nameof(price));
}