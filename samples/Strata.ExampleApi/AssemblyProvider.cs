using System.Reflection;

namespace Strata.ExampleApi;

internal static class AssemblyProvider
{
    public static readonly Assembly Current = typeof(AssemblyProvider).Assembly;
}
