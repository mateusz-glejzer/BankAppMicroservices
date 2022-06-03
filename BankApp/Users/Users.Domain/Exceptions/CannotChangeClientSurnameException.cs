namespace Users.Core.Exceptions;

public class CannotChangeClientSurnameException : DomainException
{
    public override string Code { get; } = "cannot_change_client_Surname";
    public Guid Id { get; }
    public CannotChangeClientSurnameException(Guid id) : base($"Cannot change Customer Id:{id} Surname")
    {
        Id = id;
    }
}