using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.API.Options;
using Backend.API.Services.IServices;
using Backend.Application.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace Backend.API.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly JwtOptions jwtOptions;

    public JwtTokenService(JwtOptions jwtOptions)
    {
        this.jwtOptions = jwtOptions;
    }
    public string GetToken(UserDto userDto)
    {
        var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));

        var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

        List<Claim> claims=[
            new Claim(JwtRegisteredClaimNames.Email,userDto.Email),
            new Claim(JwtRegisteredClaimNames.PreferredUsername,userDto.UserName),
            new Claim(JwtRegisteredClaimNames.NameId,userDto.Id.ToString())
        ];  

        JwtSecurityToken jwtSecurityToken=new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddSeconds(jwtOptions.LifeTimeSeconds),
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
