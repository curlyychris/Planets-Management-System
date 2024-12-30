using System;
using Backend.API.ApiEndpoints.PlanetEndpoints;
using Backend.API.ApiEndpoints.UserEndpoints;

namespace Backend.API.ApiEndpoints;

public static class ApiEndpointExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapUserEndpoints();
        endpointRouteBuilder.MapPlanetsEndpoint();
        return endpointRouteBuilder;
    }
}
