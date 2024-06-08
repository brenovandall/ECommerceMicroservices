namespace Domain.Models;

public class OrderItem : Entity<Ulid>
{
    internal OrderItem(Ulid orderId, Ulid productId, int quantity, decimal price)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        TotalPrice = price;
    }

    public Ulid OrderId { get; private set; } = default!;
    public Ulid ProductId { get; private set; } = default!;
    public int Quantity { get; private set; } = default!;
    public decimal TotalPrice { get; private set; } = default!;
}
