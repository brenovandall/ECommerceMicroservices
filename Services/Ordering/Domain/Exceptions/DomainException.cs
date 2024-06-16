namespace Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message) : base($"Domain exception: \"{message}\" throws new domain layer.")
    {
    }
}
