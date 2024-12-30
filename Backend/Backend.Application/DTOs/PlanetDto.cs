using System;

namespace Backend.Application.DTOs;

public class PlanetDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Rotation_period { get; set; }
    public required string Orbital_period { get; set; }
    public required string Diameter { get; set; }
    public required string Climate { get; set; }
    public required string Gravity { get; set; }
    public Guid UserId { get; set; }
}
