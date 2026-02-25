namespace Strata.Abstractions;

public interface IStrataPipe<TRequest, TResponse>
{
    ValueTask<Response<TResponse>> ProcessAsync(Func<ValueTask<Response<TResponse>>> next,
        RequestContext<TRequest> context,
        CancellationToken cancellationToken = default);
}
