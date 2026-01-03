namespace Common.Messaging.Events;

public abstract class BaseIntegrationEvent
{
    public Guid CorrelationId { get; set; }
    public DateTime CreationDate { get; private set; }
    public string EventType { get; set; }

    protected BaseIntegrationEvent()
    {
        CorrelationId = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
        EventType = GetType().Name;
    }
    
    protected BaseIntegrationEvent(Guid correlationId, DateTime creationDate)
    {
        CorrelationId = correlationId;
        CreationDate = creationDate;
        EventType = GetType().Name;
    }
}