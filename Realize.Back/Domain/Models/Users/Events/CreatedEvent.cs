namespace Domain.Models.Users.Events;

public class CreatedEvent : DomainEvent
{
    public Guid Id { get; private init; }
    public DateTime Time { get; private init; }

    public CreatedEvent(Guid id, DateTime time)
    {
        Id = id;
        Time = time;
    }
}