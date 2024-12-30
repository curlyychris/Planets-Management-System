using System;
using Backend.API.Extensions;
using Backend.API.Mappings;
using Backend.Application.Services.IServices;
using Backend.Contracts.Planets;
using Microsoft.AspNetCore.Components.Forms;

namespace Backend.API.ApiEndpoints.PlanetEndpoints;

public static class GetPlanetsEndpoint
{

    public static IEndpointRouteBuilder MapGetPlanetsEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("planets", async (IPlanetService planetService, HttpContext httpContext, ISwApiService swApiService) =>
        {
            Guid userId = httpContext.GetUserId();

            var result = await planetService.GetAllPlanetsAsync(userId);

            var swapiPlanetsResults = await swApiService.GetAllPlantes();


            PlanetResponse[] swPlanetsResponse = swapiPlanetsResults.isSuccessful
            ? swapiPlanetsResults.Data!.Select(x => x.MapToResponse()).ToArray()
            : [];


            return result.MapToHttpResponse(x =>
            {
                var planets=x.Select(x => x.MapToResponse()).ToList();
                planets.AddRange(swPlanetsResponse);
                return planets;
            });

        }).RequireAuthorization();
        return endpointRouteBuilder;
    }
}
