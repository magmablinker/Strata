using Axent.Abstractions;
using Microsoft.Extensions.Logging;

namespace Axent.Core;

public sealed class ErrorHandlingPipe<TRequest, TResponse>
    : IAxentPipe<TRequest, TResponse>
{
    private readonly AxentErrorHandlingOptions _options;
    private readonly ILogger<ErrorHandlingPipe<TRequest, TResponse>> _logger;

    public ErrorHandlingPipe(AxentOptions options, ILogger<ErrorHandlingPipe<TRequest, TResponse>> logger)
    {
        _options = options.ErrorHandling ?? new AxentErrorHandlingOptions();
        _logger = logger;
    }

    public Task<Response<TResponse>> ProcessAsync(
        IPipelineChain<TRequest, TResponse> chain,
        int nextIndex,
        RequestContext<TRequest> context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return chain.NextAsync(context, nextIndex, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "");

            var response = ErrorDefaults.Generic.InternalServerError();
            if (_options.EnableDetailedExceptionResponse)
            {
                response.AddMessages([e.Message, e.StackTrace ?? "StackTrace is empty"]);
            }

            return Task.FromResult(Response.Failure<TResponse>(response));
        }
    }
}
