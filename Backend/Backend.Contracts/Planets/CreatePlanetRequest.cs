using System;

namespace Backend.Contracts.Planets;

public class CreatePlanetRequest
{
    public required string Name { get; set; }
    public required string Rotation_period { get; set; }
    public required string Orbital_period { get; set; }
    public required string Diameter { get; set; }
    public required string Climate { get; set; }
    public required string Gravity { get; set; }
}
