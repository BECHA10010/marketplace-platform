namespace Common.Messaging.Events;

public abstract class BaseIntegrationEvent
{
    public Guid CorrelationId { get; init; }
    public DateTime CreationDate { get; init; } = DateTime.UtcNow;
    public string EventType => GetType().Name;
}