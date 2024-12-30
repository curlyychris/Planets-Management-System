using System;
using System.Text.Json;
using Backend.Application.Common;
using Backend.Application.DTOs;
using Backend.Application.Services.IServices;

namespace Backend.Application.Services;

public class SwApiService : ISwApiService
{
    private readonly HttpClient httpClient;
    private readonly string Base="https://swapi.info/api/";

    public SwApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task<Result<List<SwApiPlanetDto>>> GetAllPlantes()
    {
        string url=Base+"planets";
        HttpResponseMessage responseMessage=await httpClient.GetAsync(url);

        if(!responseMessage.IsSuccessStatusCode)
        {
            return new List<SwApiPlanetDto>();
        }
        string result=await responseMessage.Content.ReadAsStringAsync();
        List<SwApiPlanetDto>? data=JsonSerializer.Deserialize<List<SwApiPlanetDto>>(result,new JsonSerializerOptions{PropertyNameCaseInsensitive=true});
        if(data is null)
        {
            return new List<SwApiPlanetDto>();
        }
        return data;
    }
}
