namespace Domain.ValueObjects;

public record CustomerId
{
    public Ulid Value { get; }
    private CustomerId(Ulid value) => Value = value;

    public static CustomerId Of(Ulid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value == Ulid.Empty)
            throw new DomainException("Customer id cannot be empty");

        return new CustomerId(value);
    }
}