using OrderAPI.Data;

namespace OrderAPI.Services;

public interface IOrderService 
{
    Task<List<Order>> GetAllOrders();
    Task<Order?> GetOrderByNumber(string orderNumber);
}