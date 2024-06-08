namespace Domain.Models;

public class Customer : Entity<Ulid>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
}
