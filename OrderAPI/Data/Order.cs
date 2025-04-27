namespace OrderAPI.Data;

public class Order
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public string? OrderNumber { get; set; }
    public decimal Total { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public OrderStatus Status { get; set; }
}
