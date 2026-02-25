using Strata.Abstractions;

namespace Strata.Core;

internal sealed class TerminationPipe<TRequest, TResponse> : IStrataPipe<TRequest, TResponse>
{
    public ValueTask<Response<TResponse>> ProcessAsync(Func<ValueTask<Response<TResponse>>> next, RequestContext<TRequest> context, CancellationToken cancellationToken = default) => 
        ValueTask.FromResult(Response<TResponse>.Failure(ErrorDefaults.Generic.InternalServerError()));
}