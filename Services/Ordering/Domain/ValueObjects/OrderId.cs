namespace Domain.ValueObjects;

public record OrderId
{
    public Ulid Value { get; }
    private OrderId(Ulid value) => Value = value;

    public static OrderId Of(Ulid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value == Ulid.Empty)
            throw new DomainException("Order id cannot be empty");

        return new OrderId(value);
    }
}
