using Axent.Abstractions;

namespace Axent.Core;

internal sealed class TerminationPipe<TRequest, TResponse> : IAxentPipe<TRequest, TResponse>
{
    public ValueTask<Response<TResponse>> ProcessAsync(Func<ValueTask<Response<TResponse>>> next, RequestContext<TRequest> context, CancellationToken cancellationToken = default) => 
        ValueTask.FromResult(Response<TResponse>.Failure(ErrorDefaults.Generic.InternalServerError()));
}