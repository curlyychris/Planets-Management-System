using System;
using Backend.Application.Common;
using Backend.Application.DTOs;
using Backend.Application.Extensions;
using Backend.Application.Persistence;
using Backend.Application.Services.IServices;
using Backend.Application.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Backend.Application.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> userManager;
    private readonly IValidator<LoginUserDto> loginValidator;
    private readonly IValidator<CreateUserDto> registerValidator;

    public UserService
    (
        UserManager<User> userManager,
        IValidator<LoginUserDto> loginValidator,
        IValidator<CreateUserDto> registerValidator
    )
    {
        this.userManager = userManager;
        this.loginValidator = loginValidator;
        this.registerValidator = registerValidator;
    }

    public async Task<Result<UserDto>> Login(LoginUserDto loginUserDto)
    {
        var validationResult=await loginValidator.ValidateAsync(loginUserDto);
        if(!validationResult.IsValid)
        {
            return validationResult.Errors.MapToResultErrors(ResultTypes.badRequest);
        }
        User? user=await userManager.FindByEmailAsync(loginUserDto.Email);
        if(user is null)
        {
            return new ResultErrors{
                Errors=[],
                ResultType=ResultTypes.notFound
            };
        }
        var doesPasswordMatch=await userManager.CheckPasswordAsync(user,loginUserDto.Password);
        if(!doesPasswordMatch)
        {
            return new ResultErrors{
                Errors=[],
                ResultType=ResultTypes.unauthorized
            };
        }
        return new UserDto{
            Email=user.Email!,
            UserName=user.UserName!,
            Id=user.Id
        };
    }

    public async Task<Result<bool>> Register(CreateUserDto createUserDto)
    {
        var validationResult=await registerValidator.ValidateAsync(createUserDto);
        if(!validationResult.IsValid)
        {
            return validationResult.Errors.MapToResultErrors(ResultTypes.badRequest);
        }
        User user=new User{
            Email=createUserDto.Email,
            UserName=createUserDto.UserName
        };
        var result=await userManager.CreateAsync(user,createUserDto.Password);

        if(!result.Succeeded)
        {
            return new ResultErrors{
                Errors=[],
                ResultType=ResultTypes.badRequest
            };
        }
        return true;
    }

    


}
