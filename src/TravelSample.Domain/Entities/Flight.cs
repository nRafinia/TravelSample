﻿using Ardalis.GuardClauses;

namespace TravelSample.Domain.Entities;

public class Flight(string airline, string flightNumber, string departureTime, string arrivalTime, decimal price)
{
    public string Airline { get; init; } = Guard.Against.NullOrEmpty(airline, nameof(airline));
    public string FlightNumber { get; init; } = Guard.Against.NullOrEmpty(flightNumber, nameof(flightNumber));
    public string DepartureTime { get; init; } = Guard.Against.NullOrEmpty(departureTime, nameof(departureTime));
    public string ArrivalTime { get; init; } = Guard.Against.NullOrEmpty(arrivalTime, nameof(arrivalTime));
    public decimal Price { get; init; } = Guard.Against.Zero(price, nameof(price));
}