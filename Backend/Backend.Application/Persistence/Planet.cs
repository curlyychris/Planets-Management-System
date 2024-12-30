using System;

namespace Backend.Application.Persistence;

public class Planet
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string RotationPeriod { get; set; }
    public required string  OrbitalPeriod { get; set; }
    public required string Diameter { get; set; }
    public required string Climate { get; set; }
    public required string Gravity { get; set; }
    public User? User { get; set; }
    public Guid UserId { get; set; }
}
