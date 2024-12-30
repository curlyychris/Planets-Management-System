using System;
using Backend.Application.DTOs;

namespace Backend.API.Services.IServices;

public interface IJwtTokenService
{
    public string GetToken(UserDto userDto);
}
