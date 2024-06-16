namespace Domain.Models;

public class OrderItem : Entity<OrderItemId>
{
    internal OrderItem(OrderId orderId, ProductId productId, int quantity, decimal price)
    {
        Id = OrderItemId.Of(Ulid.NewUlid());
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        TotalPrice = price;
    }

    public OrderId OrderId { get; private set; } = default!;
    public ProductId ProductId { get; private set; } = default!;
    public int Quantity { get; private set; } = default!;
    public decimal TotalPrice { get; private set; } = default!;
}
