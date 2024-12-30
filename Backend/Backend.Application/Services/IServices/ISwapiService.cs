using System;
using Backend.Application.Common;
using Backend.Application.DTOs;

namespace Backend.Application.Services.IServices;

public interface ISwApiService
{
    public Task<Result<List<SwApiPlanetDto>>>GetAllPlantes();

}
