namespace Users.Core.Exceptions;

public class CannotChangeClientNameException : DomainException
{
    public CannotChangeClientNameException(string message) : base(message)
    {
    }
}