using Axent.Abstractions;

namespace Axent.Core;

public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    public abstract Task<Response<TResponse>> HandleAsync(RequestContext<TRequest> context,
        CancellationToken cancellationToken = default);

    public async Task<object> HandleAsync(RequestContext<object> context, CancellationToken cancellationToken = default)
    {
        if (context is not RequestContext<TRequest> typedRequest)
        {
            throw new ArgumentException($"Invalid request type. Expected {typeof(TRequest)}, but got {context.Request.GetType()}.",
                nameof(context));
        }

        return await HandleAsync(typedRequest, cancellationToken);
    }
}