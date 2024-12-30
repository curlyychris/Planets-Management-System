using System;

namespace Backend.Contracts.User;

public class RegisterRequest
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    
}
