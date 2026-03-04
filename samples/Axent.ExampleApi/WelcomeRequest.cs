using Axent.Abstractions;
using Axent.Core;

namespace Axent.ExampleApi;

internal sealed record WelcomeRequest : IRequest<string>;

internal sealed class WelcomeRequestHandler : RequestHandler<WelcomeRequest, string>
{
    public override Task<Response<string>> HandleAsync(RequestContext<WelcomeRequest> context,
        CancellationToken cancellationToken = default) =>
        Task.FromResult(Response.Success("Axent Example Api is up and running!"));
}
