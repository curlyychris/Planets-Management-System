using System;
using System.Reflection;
using Backend.Application.Persistence;
using Backend.Application.Repositories;
using Backend.Application.Repositories.IRepositories;
using Backend.Application.Services;
using Backend.Application.Services.IServices;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration config)
    {
        services.AddDbContext<DataContext>(
            x=>x.UseSqlServer(config.GetConnectionString("DefaultConnectionString"))
        );
        services.AddIdentityCore<User>().AddEntityFrameworkStores<DataContext>();
        services.AddScoped<IUserService,UserService>();
        services.AddScoped<ISwApiService, SwApiService>();
        services.AddScoped<IPlanetRepository,PlanetRepository>();
        services.AddScoped<IPlanetService,PlanetService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }


}
