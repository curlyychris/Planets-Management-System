using System;

namespace Backend.API.ApiEndpoints.PlanetEndpoints;

public static class PlanetEndpointExtensions
{
    public static IEndpointRouteBuilder MapPlanetsEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGetPlanetsEndpoint();
        endpointRouteBuilder.MapCreatePlanetEndpoint();
        return endpointRouteBuilder;
    }
}

