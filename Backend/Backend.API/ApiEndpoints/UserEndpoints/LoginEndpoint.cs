using System;
using Backend.API.Mappings;
using Backend.API.Services.IServices;
using Backend.Application.Services.IServices;
using Backend.Contracts.User;

namespace Backend.API.ApiEndpoints.UserEndpoints;

public static class LoginEndpoint
{
    public static IEndpointRouteBuilder MapLoginEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost(
            "users/login",
            async (IUserService userService, LoginRequest loginRequest, IJwtTokenService jwtTokenService) =>
        {
            var result = await userService.Login(loginRequest.MapToDto());

            return result.MapToHttpResponse(x => x.MapToResponse(jwtTokenService.GetToken(x)));
        });
        return endpointRouteBuilder;
    }
}
