namespace Domain.ValueObjects;

public record Address
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string? EmailAddress { get; } = default!;
    public string Street { get; } = default!;
    public string Country { get; } = default!;
    public string State { get; } = default!;
    public string ZipCode { get; } = default!;

    protected Address()
    {

    }

    private Address(
        string firtName,
        string lastName,
        string emailAddress,
        string street,
        string country,
        string state,
        string zipCode)
    {
        FirstName = firtName;
        LastName = lastName;
        EmailAddress = emailAddress;
        Street = street;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public static Address Of(
        string firtName,
        string lastName,
        string emailAddress,
        string street,
        string country,
        string state,
        string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress, nameof(emailAddress));
        ArgumentException.ThrowIfNullOrWhiteSpace(street, nameof(street));

        return new Address(
            firtName,
            lastName,
            emailAddress,
            street,
            country,
            state,
            zipCode);
    }
}
