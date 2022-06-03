namespace Users.Core.Exceptions;

public class UserExistsException : DomainException
{
    public override string Code { get; } = "user_exists_in_database";
    public Guid Id { get; }
    public UserExistsException(Guid id) : base($"User with id: {id} exists in database, cannot create new one with the same Id.")
    {
        Id = id;
    }
}