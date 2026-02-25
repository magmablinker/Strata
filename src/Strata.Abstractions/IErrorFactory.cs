namespace Strata.Abstractions;

public interface IErrorFactory
{
    Error Create(Exception exception);
}