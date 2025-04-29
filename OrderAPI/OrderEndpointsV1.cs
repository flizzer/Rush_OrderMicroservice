using Microsoft.AspNetCore.Http.HttpResults;
using OrderAPI.Data;
using OrderAPI.Services;

namespace OrderAPI;

public static class OrderEndpointsV1
{
    public static RouteGroupBuilder MapOrdersAPIV1(this RouteGroupBuilder orderGroup)
    {
        orderGroup.MapGet("/", GetAllOrders);
        orderGroup.MapGet("/{orderNumber}", GetOrderByNumber);
        orderGroup.MapPost("/", CreateOrder);
        return orderGroup;
    }

    public static async Task<Ok<List<Order>>> GetAllOrders(IOrderService orderService)
    {
        var orders = await orderService.GetAllOrders();
        return TypedResults.Ok(orders);
    }

    public static async Task<Results<Ok<Order>, NotFound>> GetOrderByNumber(string orderNumber
        , IOrderService orderService)
    {
        var order = await orderService.GetOrderByNumber(orderNumber);
        if (order != null)
            return TypedResults.Ok(order);
        return TypedResults.NotFound();
    }

    public static async Task<Created<Order>> CreateOrder(long customerId
        , IOrderService orderService)
    {
        var newOrder = new Order
        {
            CustomerId = customerId,
            CreatedDate = DateTime.Now,
            Status = OrderStatus.Pending
        };
        await orderService.CreateOrder(newOrder);
        return TypedResults.Created<Order>("/orders/V1/{newOrder.OrderNumber}", newOrder);
    }
}