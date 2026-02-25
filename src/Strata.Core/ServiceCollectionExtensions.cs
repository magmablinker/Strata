using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Strata.Abstractions;

namespace Strata.Core;

public static class ServiceCollectionExtensions
{
    public static StrataBuilder AddStrata(this IServiceCollection services)
    {
        services.AddScoped<ISender, Sender>()
            .AddScoped<IRequestContextFactory, RequestContextFactory>()
            .AddScoped<IPipelineExecutorService, PipelineExecutorService>()
            .AddScoped(typeof(IHandlerPipe<,>), typeof(HandlerPipe<,>));
        return new StrataBuilder(services);
    }
    
    public static StrataBuilder AddRequestHandlers(this StrataBuilder builder, Assembly assembly)
    {
        var handlerTypes = assembly.GetTypes()
            .Where(t => t is { IsAbstract: false, IsInterface: false })
            .SelectMany(t => t.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                .Select(i => new
                {
                    Implementation = t,
                    Interface = i
                }))
            .ToList();

        foreach (var handler in handlerTypes)
        {
            builder.Services.AddScoped(handler.Interface, handler.Implementation);
        }

        return builder;
    }
}