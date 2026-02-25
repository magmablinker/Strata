namespace Axent.Abstractions;

public interface IAxentPipe<TRequest, TResponse>
{
    ValueTask<Response<TResponse>> ProcessAsync(Func<ValueTask<Response<TResponse>>> next,
        RequestContext<TRequest> context,
        CancellationToken cancellationToken = default);
}
