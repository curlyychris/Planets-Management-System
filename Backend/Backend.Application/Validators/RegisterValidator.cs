using System;
using Backend.Application.DTOs;
using Backend.Application.Persistence;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Backend.Application.Validators;

public class RegisterValidator:AbstractValidator<CreateUserDto>
{
    private readonly UserManager<User> userManager;

    public RegisterValidator(UserManager<User> userManager)
    {
       RuleFor(x=>x.Email).EmailAddress().MustAsync(IsEmailUnique).WithMessage("Email already exists");
       RuleFor(x=>x.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
            .WithMessage("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
       RuleFor(x=>x.UserName).MinimumLength(3).MustAsync(IsUserNameUnique).WithMessage("Username already exists");
        this.userManager = userManager;
    }

    async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken)
    {
        var user=await userManager.FindByEmailAsync(email);

        return user==null;

    }
    
    async Task<bool> IsUserNameUnique(string userName, CancellationToken cancellationToken)
    {
        var user=await userManager.FindByNameAsync(userName);

        return user==null;

    }
}
