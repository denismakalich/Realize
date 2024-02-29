namespace Domain.Models.Users.Events;

public class PasswordResetRequestEvent: DomainEvent
{
    public Guid Id { get; private init; }
    public DateTime Time { get; private init; }

    public PasswordResetRequestEvent(Guid id, DateTime time)
    {
        Id = id;
        Time = time;
    }
}