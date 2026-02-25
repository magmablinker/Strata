using Microsoft.Extensions.DependencyInjection;

namespace Strata.Core;

public sealed class StrataBuilder
{
    public IServiceCollection Services { get; }
    
    public StrataBuilder(IServiceCollection serviceCollection)
    {
        Services = serviceCollection;
    }
}