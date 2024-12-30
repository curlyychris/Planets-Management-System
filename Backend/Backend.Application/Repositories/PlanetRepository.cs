using System;
using Backend.Application.Persistence;
using Backend.Application.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Repositories;

public class PlanetRepository : IPlanetRepository
{
    private readonly DataContext dataContext;

    public PlanetRepository(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public void CreatePlanetAsync(Planet planet)
    {
        dataContext.Planets.Add(planet);
    }

    public Task<List<Planet>> GetMyPlanetsAsync(Guid userId)
    {
        return dataContext.Planets.Where(x=>x.UserId==userId).ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await dataContext.SaveChangesAsync()>0;
    }
}
