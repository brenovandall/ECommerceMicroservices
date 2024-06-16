namespace Domain.ValueObjects;

public record ProductId
{
    public Ulid Value { get; }
    private ProductId(Ulid value) => Value = value;

    public static ProductId Of(Ulid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value == Ulid.Empty)
            throw new DomainException("Product id cannot be empty");

        return new ProductId(value);
    }
}
