namespace Users.Core.Exceptions;

public class CannotChangeClientEmailException: DomainException
{
    public CannotChangeClientEmailException(string message) : base(message)
    {
    }
}