using System;
using Backend.Application.Persistence;

namespace Backend.Application.Repositories.IRepositories;

public interface IPlanetRepository
{
    public void CreatePlanetAsync(Planet planet);
    public Task<List<Planet>> GetMyPlanetsAsync(Guid userId);

    public Task<bool> SaveChangesAsync();
}
