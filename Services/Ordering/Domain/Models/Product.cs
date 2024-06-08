namespace Domain.Models;

public class Product : Entity<Ulid>
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
}
