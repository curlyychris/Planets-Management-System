using System;

namespace Backend.Application.DTOs;

public class SwApiPlanetDto
{   
    public required string Name { get; set; }
    public required string Rotation_period { get; set; }
    public required string Orbital_period { get; set; }
    public required string Diameter { get; set; }
    public required string Climate { get; set; }
    public required string Gravity { get; set; }
}
