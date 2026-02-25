using Strata.Abstractions;
using Strata.Core;
using Strata.ExampleApi;
using Strata.Extensions.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

builder.Services.AddStrata()
    .AddRequestHandlers(AssemblyProvider.Current);

builder.Services.AddScoped(typeof(IStrataPipe<,>), typeof(ExampleRequestPipe<,>));

var app = builder.Build();

app.MapGet("/", () => "Strata Example Api is up and running!");

app.MapGet("/api/example", async (ISender sender, CancellationToken cancellationToken) =>
{
    var request = new ExampleRequest
    {
        Message = "Hello World!"
    };

    var response = await sender.SendAsync(request, cancellationToken);
    return response.ToResult();
});

app.Run();