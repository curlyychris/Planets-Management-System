using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace Backend.Application.Common;

public enum ResultTypes
{
    ok,
    notFound,
    unauthorized,
    badRequest
}

public struct Result<T>
{
    public T? Data { get; set; }
    public bool isSuccessful { get; set; }
    public List<ResultError>? Errors { get; set; }
    public ResultTypes ResultType { get; set; }

    public static implicit operator Result<T> (T value)
    {
        return new Result<T>{Data=value,isSuccessful=true,ResultType=ResultTypes.ok};
    }
    public static implicit operator Result<T>(ResultErrors resultErrors)
    {
        return new Result<T> {isSuccessful=false,Errors=resultErrors.Errors,ResultType=resultErrors.ResultType};
    }  
}

public class ResultError
{
    public required string Name { get; set; }
    public required string Message { get; set; }
}
public class ResultErrors
{
    public required List<ResultError> Errors { get; set; }
    public ResultTypes ResultType { get; set; }
}

