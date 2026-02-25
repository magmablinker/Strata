using Axent.Abstractions;
using Axent.Core;

namespace Axent.ExampleApi;

internal sealed class ExampleRequest : IRequest<ExampleResponse>
{
    public required string Message { get; init; }
}

internal sealed class ExampleResponse
{
    public required string Message { get; init; }
}

internal sealed class ExampleRequestHandler : RequestHandler<ExampleRequest, ExampleResponse>
{
    private readonly ILogger<ExampleRequestHandler> _logger;

    public ExampleRequestHandler(ILogger<ExampleRequestHandler> logger)
    {
        _logger = logger;
    }

    public override Task<Response<ExampleResponse>> HandleAsync(RequestContext<ExampleRequest> context, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Message from request '{0}'", context.Request.Message);
        return Task.FromResult(Response<ExampleResponse>.Success(new () { Message = context.Request.Message }));
    }
}