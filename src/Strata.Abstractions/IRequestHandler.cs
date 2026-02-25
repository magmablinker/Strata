namespace Strata.Abstractions;

public interface IRequestHandler
{
    Task<object> HandleAsync(RequestContext<object> context, CancellationToken cancellationToken = default);
}

public interface IRequestHandler<TRequest, TResponse> : IRequestHandler
    where TRequest : class, IRequest<TResponse>
{
    Task<Response<TResponse>> HandleAsync(RequestContext<TRequest> context, CancellationToken cancellationToken = default);
}