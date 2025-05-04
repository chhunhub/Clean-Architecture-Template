namespace CleanArchitectureWeb.Domain.Abstractions;
public abstract class Entity
{
    public Guid Id { get; set; }
    private List<IDomainEvent> _domainEventList = new();
    public IReadOnlyCollection<IDomainEvent> _domainEventCollection => _domainEventList.ToList();
    public void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEventList.Add(domainEvent);
    }
    public void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        _domainEventList.Remove(domainEvent);
    }
    public void ClearDomainEvent()
    {
        _domainEventList.Clear();
    }
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEventList;
    }
}
