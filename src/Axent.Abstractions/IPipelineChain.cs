namespace Axent.Abstractions;

public interface IPipelineChain<TRequest, TResponse>
{
    Task<Response<TResponse>> NextAsync(
        RequestContext<TRequest> context,
        int index,
        CancellationToken cancellationToken);
}
