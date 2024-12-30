using System;

namespace Backend.Contracts.User;

public class LoginRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }

}
