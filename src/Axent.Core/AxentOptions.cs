namespace Axent.Core;

public sealed class AxentOptions
{
    /// <summary>
    /// Determines whether error handling is enabled or exceptions should be "forwarded" to the consumer
    /// of the library.
    /// No errors will be caught if the options are not set.
    /// </summary>
    public AxentErrorHandlingOptions? ErrorHandling { get; set; }
}

public sealed class AxentErrorHandlingOptions
{
    /// <summary>
    /// Determines whether the full exception gets returned or not, when the `ErrorHandlingPipe` is registered.
    /// Defaults to false
    /// </summary>
    public bool EnableDetailedExceptionResponse { get; set; }
}
