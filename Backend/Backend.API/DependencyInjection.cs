using System;
using System.Text;
using Backend.API.Options;
using Backend.API.Services;
using Backend.API.Services.IServices;
using Backend.Application.DTOs;
using Backend.Application.Repositories;
using Backend.Application.Repositories.IRepositories;
using Backend.Application.Services;
using Backend.Application.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Backend.API;

public static class DependencyInjection
{
    
    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        JwtOptions jwtOptions=configuration.GetSection("JwtTokenOptions").Get<JwtOptions>()!;
        services.AddSingleton(jwtOptions);
        services.AddSingleton<IJwtTokenService, JwtTokenService>();
        services.AddAuthentication().AddJwtBearer(x=>{
            x.TokenValidationParameters=new TokenValidationParameters
            {
                ValidateIssuerSigningKey=true,
                ValidateLifetime=true,
                ValidateIssuer=false,
                ValidateAudience=false,
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))   
            };

        });
        services.AddAuthorization();
        services.AddHttpClient();
        services.AddCors(x=>{
            x.AddPolicy("defaultPolicy",x=>x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
        });
        return services;
    }
}
