using System;
using Backend.Application.Common;
using Backend.Application.DTOs;

namespace Backend.Application.Services.IServices;

public interface IUserService
{
    public Task<Result<bool>> Register (CreateUserDto createUserDto);
    public Task<Result<UserDto>> Login (LoginUserDto loginUserDto);
    
}

