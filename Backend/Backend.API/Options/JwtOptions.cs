using System;

namespace Backend.API.Options;

public class JwtOptions
{
    public required string Key { get; set; }
    public int LifeTimeSeconds { get; set; }
}
