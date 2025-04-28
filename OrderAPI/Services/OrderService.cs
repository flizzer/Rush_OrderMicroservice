using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;

namespace OrderAPI.Services;

public class OrderService : IOrderService
{
    private readonly OrderDBContext _orderDBContext; 

    public OrderService(OrderDBContext orderDBContext)
    {
        _orderDBContext = orderDBContext;
    }
    public async Task<List<Order>> GetAllOrders()
    {
        return await _orderDBContext.Orders.ToListAsync();
    }

    public async Task<Order?> GetOrderByNumber(string orderNumber)
    {
        return _orderDBContext.Orders
            .Where(o => o.OrderNumber == orderNumber)
            .FirstOrDefault();
    }
}