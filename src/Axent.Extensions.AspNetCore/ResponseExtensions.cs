using Axent.Abstractions;
using Microsoft.AspNetCore.Http;
using Axent.Core;

namespace Axent.Extensions.AspNetCore;

public static class ResponseExtensions
{
    public static IResult ToResult<T>(this Response<T> response)
    {
        if (response.IsSuccess)
        {
            if (typeof(T) == typeof(Unit) || response.Value is null)
                return Results.NoContent();

            return Results.Ok(response.Value);
        }

        var detail = response.Error.Messages.Count != 0
            ? string.Join(", ", response.Error.Messages)
            : null;

        return Results.Problem(new()
        {
            Status = (int)response.Error.StatusCode,
            Detail = detail
        });
    }
}