using Strata.Abstractions;

namespace Strata.ExampleApi;

internal sealed class ExampleRequestPipe<TRequest, TResponse> : IStrataPipe<TRequest, TResponse>
{
    private readonly ILogger<ExampleRequestPipe<TRequest, TResponse>> _logger;

    public ExampleRequestPipe(ILogger<ExampleRequestPipe<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }
    
    public ValueTask<Response<TResponse>> ProcessAsync(Func<ValueTask<Response<TResponse>>> next, RequestContext<TRequest> context, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("This pipe runs during every request.");
        return next();
    }
}