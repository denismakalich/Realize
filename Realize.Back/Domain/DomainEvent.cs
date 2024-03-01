namespace Domain;

public abstract class DomainEvent
{
    public DateTime RaiseTime { get; private init; }

    protected DomainEvent()
    {
    }

    protected DomainEvent(DateTime raiseTime) => RaiseTime = raiseTime;
}