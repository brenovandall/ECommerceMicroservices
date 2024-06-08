namespace Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Ulid Id => Ulid.NewUlid();
    public DateTime OccurredOn => DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName!;
}
