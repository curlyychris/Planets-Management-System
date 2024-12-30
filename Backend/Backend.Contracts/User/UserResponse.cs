using System;

namespace Backend.Contracts.User;

public class UserResponse
{
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string Token { get; set; }
}
