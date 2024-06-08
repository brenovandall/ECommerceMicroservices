namespace Domain.Models;

public class Order : Aggregate<Ulid>
{
    private readonly List<OrderItem> _orderItems = new();
    private IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public Ulid CustomerId { get; private set; } = default!;
    public string OrderName { get; private set; } = default!;
    public Address ShippingAddress { get; private set; } = default!;
    public Address BillingAddress { get;  private set; } = default!;
    public Payment Payment { get; private set; } = default!;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public decimal TotalPrice
    {
        get => OrderItems.Sum(x => x.TotalPrice * x.Quantity);
        private set { }
    }
}
