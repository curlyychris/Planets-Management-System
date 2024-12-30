using System;
using Backend.Application.Common;

namespace Backend.API.Mappings;

public static class ResultsMapping
{
    public static IResult MapToHttpResponse<T,K>(this Result<T> result,Func<T,K> func)
    {
        return result.ResultType switch
        {
            ResultTypes.ok=>TypedResults.Ok(func(result.Data!)),
            ResultTypes.notFound=>TypedResults.NotFound(),
            ResultTypes.unauthorized=>TypedResults.Unauthorized(),
            ResultTypes.badRequest=>TypedResults.BadRequest(result.Errors),
            _=> TypedResults.Conflict()
        };
    }
}
