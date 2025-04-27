using Microsoft.AspNetCore.Http.HttpResults;
using OrderAPI.Data;
using OrderAPI.Services;

namespace Rush_OrderMicroservice;

public static class OrderEndpointsV1
{
    public static RouteGroupBuilder MapOrdersAPIV1(this RouteGroupBuilder orderGroup)
    {
        orderGroup.MapGet("/", GetAllOrders);
        return orderGroup;
    }

    public static async Task<Ok<List<Order>>> GetAllOrders(IOrderService orderService)
    {
        throw new NotImplementedException();
    }
}