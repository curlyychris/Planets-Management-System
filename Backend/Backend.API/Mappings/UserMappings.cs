using System;
using Backend.Application.DTOs;
using Backend.Contracts.User;

namespace Backend.API.Mappings;

public static class UserMappings
{
    public static CreateUserDto MapToDto(this RegisterRequest registerRequest)
    {
        return new CreateUserDto{
            Email=registerRequest.Email,
            Password=registerRequest.Password,
            UserName=registerRequest.UserName
        };
    }
    public static LoginUserDto MapToDto(this LoginRequest loginRequest)
    {
        return new LoginUserDto
        {
            Email=loginRequest.Email,
            Password=loginRequest.Password
        };
    }
    public static UserResponse MapToResponse(this UserDto userDto,string token)
    {
        return new UserResponse
        {
            Email=userDto.Email,
            UserName=userDto.UserName,
            Token=token           
        };
    }
}
