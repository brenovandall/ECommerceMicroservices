namespace Application.Dtos;

public record AddressDto(
    string FirstName,
    string LastName,
    string EmailAddress,
    string Street,
    string Country,
    string State,
    string ZipCode);
