namespace Domain.Models.Users.Events;

public abstract class DomainEvent
{
    public DateTime RaiseTime { get; private init; }

    protected DomainEvent()
    {
    }

    protected DomainEvent(DateTime raiseTime) => RaiseTime = raiseTime;
}