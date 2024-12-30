using System;
using Backend.Application.Common;
using Backend.Application.Common.Mappings;
using Backend.Application.DTOs;
using Backend.Application.Persistence;
using Backend.Application.Repositories.IRepositories;
using Backend.Application.Services.IServices;

namespace Backend.Application.Services;

public class PlanetService : IPlanetService
{
    private readonly IPlanetRepository planetRepository;
    private readonly IUserRepository userRepository;

    public PlanetService(IPlanetRepository planetRepository,IUserRepository userRepository)
    {
        this.planetRepository = planetRepository;
        this.userRepository = userRepository;
    }

    public async Task<Result<PlanetDto>> CreatePlanetAsync(CreatePlanetDto createPlanetDto)
    {
        bool doesUserExist=await userRepository.DoesUserExist(createPlanetDto.UserId);
        if(!doesUserExist)
        {
            return new ResultErrors
            {
                 Errors=[],
                 ResultType=ResultTypes.notFound
            };
        }
        var planet=createPlanetDto.MapToPlanet();
        planetRepository.CreatePlanetAsync(planet);
        bool saveChanges=await planetRepository.SaveChangesAsync();
        if(!saveChanges)
        {
            return new ResultErrors
            {
                Errors=[],
                ResultType=ResultTypes.badRequest
            };
        }
        return planet.MapToPlanetDto();
    }

    public async Task<Result<List<PlanetDto>>> GetAllPlanetsAsync(Guid userId)
    {
        List<Planet> planets=await planetRepository.GetMyPlanetsAsync(userId);
        return planets.MapToPlanetDtos();
    }
}
