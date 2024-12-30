using System;
using Backend.Application.DTOs;
using FluentValidation;

namespace Backend.Application.Validators;

public class LoginValidator:AbstractValidator<LoginUserDto>
{

    public LoginValidator()
    {
        
        RuleFor(x=>x.Email).EmailAddress();
        RuleFor(x=>x.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
            .WithMessage("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
    }
}
