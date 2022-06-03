namespace Users.Core.Exceptions;

public class CannotChangeClientNameException : DomainException
{
    public override string Code { get; } = "cannot_change_client_name";
    public Guid Id { get; }
    public CannotChangeClientNameException(Guid id) : base($"Cannot change Customer Id:{id} Name")
    {
        Id = id;
    }
}