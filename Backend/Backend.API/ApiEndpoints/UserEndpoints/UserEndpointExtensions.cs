using System;

namespace Backend.API.ApiEndpoints.UserEndpoints;

public static class UserEndpointExtensions
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapLoginEndpoint();
        endpointRouteBuilder.MapRegisterEndpoint();
        return endpointRouteBuilder;
    }
}
