namespace Users.Core.Exceptions;

public class CannotChangeClientSurnameException : DomainException
{
    public CannotChangeClientSurnameException(string message) : base(message)
    {
    }
}