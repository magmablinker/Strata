using Axent.Abstractions;

namespace Axent.Core;

public sealed class AxentConfigurationException(string message) : AxentException(message);