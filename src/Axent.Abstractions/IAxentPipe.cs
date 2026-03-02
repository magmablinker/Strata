namespace Axent.Abstractions;

/// <summary>
/// Marker interface, do not implement it.
/// </summary>
public interface IAxentPipe;

public interface IAxentPipe<TRequest, TResponse> : IAxentPipe
{
    Task<Response<TResponse>> ProcessAsync(
        IPipelineChain<TRequest, TResponse> chain,
        int nextIndex,
        RequestContext<TRequest> context,
        CancellationToken cancellationToken = default);
}
