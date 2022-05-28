namespace Users.Core.Exceptions;

public class CannotChangeClientEmailException : DomainException
{
    public override string Code { get; } = "cannot_change_client_email";
    public Guid Id { get; }

    public CannotChangeClientEmailException(Guid id) : base(
        $"Cannot change Customer: {id} email")
    {
        Id = id;
    }
}