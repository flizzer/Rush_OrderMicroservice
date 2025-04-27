namespace OrderAPI.Data;

public struct OrderStatus
{
    public const string Pending = "Pending";
    public const string Ordered = "Ordered";
    public const string Billed = "Billed";
    public const string Shipped = "Shipped";
    public const string Delivered= "Delivered";
}
