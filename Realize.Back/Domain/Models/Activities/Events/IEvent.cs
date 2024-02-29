namespace Domain.Models.Activities.Events;

public interface IEvent
{
    public Guid Id { get; }
    public string Data { get; }
    public Guid ActivityId { get; }
}