using System;
using Backend.Application.Common;
using Backend.Application.DTOs;

namespace Backend.Application.Services.IServices;

public interface IPlanetService
{
    public Task<Result<List<PlanetDto>>> GetAllPlanetsAsync(Guid userId);
    public Task<Result<PlanetDto>> CreatePlanetAsync(CreatePlanetDto createPlanetDto);// anything that has to do w task is async
}
