using OrderAPI.Data;

namespace OrderAPI.Services;

public class OrderService : IOrderService
{
    public Task<List<Order>> GetAllOrders()
    {
        throw new NotImplementedException();
    }
}