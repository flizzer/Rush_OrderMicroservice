using Microsoft.AspNetCore.Http.HttpResults;
using OrderAPI.Data;
using OrderAPI.Services;

namespace OrderAPI;

public static class OrderEndpointsV1
{
    public static RouteGroupBuilder MapOrdersAPIV1(this RouteGroupBuilder orderGroup)
    {
        orderGroup.MapGet("/", GetAllOrders);
        return orderGroup;
    }

    public static async Task<Ok<List<Order>>> GetAllOrders(IOrderService orderService)
    {
        var orders = await orderService.GetAllOrders();
        return TypedResults.Ok(orders);
    }
}