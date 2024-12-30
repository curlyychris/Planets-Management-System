using System;
using Azure;
using Backend.Application.DTOs;
using Backend.Contracts.Planets;

namespace Backend.API.Mappings;

public static class PlanetsMappings
{
    public static CreatePlanetDto MapToDto(this CreatePlanetRequest createPlanetRequest, Guid userId)
    {
        return new CreatePlanetDto
        {
            Climate=createPlanetRequest.Climate,
            Diameter=createPlanetRequest.Diameter,
            Gravity=createPlanetRequest.Gravity,
            Name=createPlanetRequest.Name,
            Orbital_period=createPlanetRequest.Orbital_period,
            Rotation_period=createPlanetRequest.Rotation_period,
            UserId=userId
        };
    }
    public static PlanetResponse MapToResponse(this PlanetDto planetDto)
    {
        return new PlanetResponse
        {
            Climate=planetDto.Climate,
            Diameter=planetDto.Diameter,
            Gravity=planetDto.Gravity,
            Name=planetDto.Name,
            Orbital_period=planetDto.Orbital_period,
            Rotation_period=planetDto.Rotation_period,
            Id=planetDto.Id
        };
    }
        public static PlanetResponse MapToResponse(this SwApiPlanetDto planetDto)
    {
        return new PlanetResponse
        {
            Climate=planetDto.Climate,
            Diameter=planetDto.Diameter,
            Gravity=planetDto.Gravity,
            Name=planetDto.Name,
            Orbital_period=planetDto.Orbital_period,
            Rotation_period=planetDto.Rotation_period,
            Id=Guid.NewGuid()
        };
    }


}
