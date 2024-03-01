namespace Domain;

public abstract class EntityWithEvents
{
    private readonly List<DomainEvent> _domainEvents;
    public bool HasRaisedEvents => _domainEvents.Any<DomainEvent>();

    protected EntityWithEvents() => _domainEvents = new List<DomainEvent>();

    protected void RaiseEvent(DomainEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull((object)domainEvent, nameof(domainEvent));

        _domainEvents.Add(domainEvent);
    }

    public IEnumerable<DomainEvent> ListRaisedEvents() => _domainEvents;

    public void CleadEvents() => _domainEvents.Clear();
}