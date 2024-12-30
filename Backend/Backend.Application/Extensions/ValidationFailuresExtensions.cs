using System;
using Backend.Application.Common;
using FluentValidation.Results;

namespace Backend.Application.Extensions;

public static class ValidationFailuresExtensions
{
    public static ResultErrors MapToResultErrors(this List<ValidationFailure> validationFailures, ResultTypes resultType)
    {
        return new ResultErrors{
            ResultType=resultType,
            Errors=validationFailures.Select(x=>new ResultError{Name=x.PropertyName,Message=x.ErrorMessage}).ToList()
        };
    }
}
