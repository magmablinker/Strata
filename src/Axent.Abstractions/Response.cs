using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Axent.Abstractions;

public class Response
{
    public virtual Error? Error { get; init; }

    [MemberNotNullWhen(false, nameof(Error))]
    public virtual bool IsSuccess => Error is null;

    [MemberNotNullWhen(true, nameof(Error))]
    public virtual bool IsFailure => !IsSuccess;

    public static Response Failure(Error error) => new() { Error = error };
    public static Response Success() => new();
}

public sealed class Response<TResponse> : Response
{
#pragma warning disable S1185
    public override Error? Error => base.Error;
#pragma warning restore S1185

    [MemberNotNullWhen(false, nameof(Error))]
    [MemberNotNullWhen(true, nameof(Value))]
    public override bool IsSuccess => base.IsSuccess;

    [MemberNotNullWhen(true, nameof(Error))]
    [MemberNotNullWhen(false, nameof(Value))]
    public override bool IsFailure => !IsSuccess;

    public TResponse? Value { get; init; }

    public static new Response<TResponse> Failure(Error error) => new() { Error = error };
    public static Response<TResponse> Success(TResponse value) => new() { Value = value };
}