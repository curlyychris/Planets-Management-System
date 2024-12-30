using System;

namespace Backend.Application.DTOs;

public class UserDto
{
    public required Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
}
