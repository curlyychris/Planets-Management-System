using System;
using Backend.API.Extensions;
using Backend.API.Mappings;
using Backend.Application.DTOs;
using Backend.Application.Repositories.IRepositories;
using Backend.Application.Services.IServices;
using Backend.Contracts.Planets;

namespace Backend.API.ApiEndpoints.PlanetEndpoints;

public static class CreatePlanetEndpoint
{
    public static IEndpointRouteBuilder MapCreatePlanetEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("planets", async(IPlanetService planetService, CreatePlanetRequest createPlanetRequest,HttpContext httpContext)=>
        {
            Guid userId=httpContext.GetUserId();
            var result=await planetService.CreatePlanetAsync(createPlanetRequest.MapToDto(userId));
            return result.MapToHttpResponse(x=>x.MapToResponse());
        }).RequireAuthorization();
        return endpointRouteBuilder;
    }

}
