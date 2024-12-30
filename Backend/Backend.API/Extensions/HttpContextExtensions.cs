using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Backend.API.Extensions;

public static class HttpContextExtensions
{
    public static Guid GetUserId(this HttpContext httpContext)
    {
        string? userIdText=httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(Guid.TryParse(userIdText,out Guid id))
        {
            return id;
        }
        return Guid.Empty;
    }
}
