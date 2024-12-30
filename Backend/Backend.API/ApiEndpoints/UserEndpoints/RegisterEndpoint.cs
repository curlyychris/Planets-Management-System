using System;
using Backend.API.Mappings;
using Backend.Application.Services.IServices;
using Backend.Contracts.User;

namespace Backend.API.ApiEndpoints.UserEndpoints;

public static class RegisterEndpoint
{
    public static IEndpointRouteBuilder MapRegisterEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost(
                "users/register",
                async (IUserService userService, RegisterRequest registerRequest) =>
                {
                    var result = await userService.Register(registerRequest.MapToDto());
                    return result.MapToHttpResponse(x=>new {});
                }
            );
        return endpointRouteBuilder;
    }
}
