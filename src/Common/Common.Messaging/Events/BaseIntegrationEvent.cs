namespace Common.Messaging.Events;

public abstract class BaseIntegrationEvent
{
    public string CorrelationId { get; set; }
    public DateTime CreationDate { get; private set; }
    public string EventType { get; set; }

    protected BaseIntegrationEvent()
    {
        CorrelationId = Guid.NewGuid().ToString();
        CreationDate = DateTime.UtcNow;
        EventType = GetType().Name;
    }
    
    protected BaseIntegrationEvent(Guid correlationId, DateTime creationDate)
    {
        CorrelationId = correlationId.ToString();
        CreationDate = creationDate;
        EventType = GetType().Name;
    }
}