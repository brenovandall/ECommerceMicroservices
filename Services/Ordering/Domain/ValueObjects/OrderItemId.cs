namespace Domain.ValueObjects;

public record OrderItemId
{
    public Ulid Value { get; }
    private OrderItemId(Ulid value) => Value = value;

    public static OrderItemId Of(Ulid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value == Ulid.Empty)
            throw new DomainException("Order item id cannot be empty");

        return new OrderItemId(value);
    }
}
