using System;
using Backend.Application.DTOs;
using Backend.Application.Persistence;

namespace Backend.Application.Common.Mappings;

public static class PlanetMappings
{
    public static Planet MapToPlanet(this CreatePlanetDto createPlanetDto)
    {
        return new Planet
        {
            Climate=createPlanetDto.Climate,
            Diameter=createPlanetDto.Diameter,
            Gravity=createPlanetDto.Gravity,
            Name=createPlanetDto.Name,
            OrbitalPeriod=createPlanetDto.Orbital_period,
            RotationPeriod=createPlanetDto.Rotation_period,
            UserId=createPlanetDto.UserId
        };
    }
    public static PlanetDto MapToPlanetDto(this Planet planet)
    {
        return new PlanetDto
        {
            Climate=planet.Climate,
            Diameter=planet.Diameter,
            Gravity=planet.Gravity,
            Name=planet.Name,
            Orbital_period=planet.OrbitalPeriod,
            Rotation_period=planet.RotationPeriod,
            UserId=planet.UserId,
            Id=planet.Id
        };
    }
    public static List<PlanetDto> MapToPlanetDtos(this List<Planet> planets)
    {
        return planets.Select(x=>x.MapToPlanetDto()).ToList();
    }

}
