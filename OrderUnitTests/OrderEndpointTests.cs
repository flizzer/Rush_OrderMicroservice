using OrderAPI;
using OrderAPI.Data;
using OrderAPI.Services;
using Moq;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OrderUnitTests;

public class OrderEndpointTests
{
    [Fact]
    public async Task OrderEndpointsV1_GetAllOrders_Returns_Orders()
    {
        //Arrange
        var createdDate = DateTime.Now;
        var mock = new Mock<IOrderService>();
        mock.Setup(mock => mock.GetAllOrders())
            .ReturnsAsync(new List<Order>{
                new Order
                {
                    Id = 1,
                    CustomerId = 2,
                    OrderNumber = null,
                    Total = null,
                    CreatedDate = createdDate,
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Id = 2,
                    CustomerId = 50,
                    OrderNumber = "1001",
                    Total = 100.00m,
                    CreatedDate = createdDate,
                    Status = OrderStatus.Billed 
                }
            });
        
        //Act
        var result = await OrderEndpointsV1.GetAllOrders(mock.Object);

        //Assert
        Assert.IsType<Ok<List<Order>>>(result);
        Assert.NotNull(result.Value);
        Assert.NotEmpty(result.Value);
        Assert.Collection(result.Value, order1 =>
        {
            Assert.Equal(1, order1.Id);
            Assert.Equal(2, order1.CustomerId);
            Assert.Null(order1.OrderNumber);
            Assert.Null(order1.Total);
            Assert.Equal(createdDate, order1.CreatedDate);
            Assert.Equal(OrderStatus.Pending, order1.Status);
        }, order2 =>
        {
            Assert.Equal(2, order2.Id);
            Assert.Equal(50, order2.CustomerId);
            Assert.Equal("1001", order2.OrderNumber);
            Assert.Equal(100.00m, order2.Total);
            Assert.Equal(createdDate, order2.CreatedDate);
            Assert.Equal(OrderStatus.Billed, order2.Status);
        });
    }

    [Fact]
    public async Task OrderEndpointsV1_GetOrderByNumber_Returns_Order()
    {
        //Arrange
        var createdDate = DateTime.Now;
        var mock = new Mock<IOrderService>();
        mock.Setup(mock => mock.GetOrderByNumber(
            It.Is<string>(orderNumber => orderNumber == "1000")))
            .ReturnsAsync(
                new Order {
                    Id = 2,
                    CustomerId = 50,
                    OrderNumber = "1000",
                    Total = 200.00m,
                    CreatedDate = createdDate,
                    Status = OrderStatus.Delivered
            });

        //Act
        var result = await OrderEndpointsV1.GetOrderByNumber("1000", mock.Object);

        //Assert
        Assert.IsType<Results<Ok<Order>, NotFound>>(result);
        var okResult = (Ok<Order>)result.Result;
        Assert.NotNull(okResult);
        Assert.Equal(2, okResult.Value!.Id);
        Assert.Equal(50, okResult.Value.CustomerId);
        Assert.Equal("1000", okResult.Value.OrderNumber);
        Assert.Equal(200.00m, okResult.Value.Total);
        Assert.Equal(createdDate, okResult.Value.CreatedDate);
        Assert.Equal(OrderStatus.Delivered, okResult.Value.Status);
    }

    [Fact]
    public async Task OrderEndpointsV1_GetOrderByNumber_Returns_NotFound()
    {
        //Arrange
        var createdDate = DateTime.Now;
        var mock = new Mock<IOrderService>();
        mock.Setup(mock => mock.GetOrderByNumber(
            It.Is<string>(orderNumber => orderNumber == "1000")))
            .ReturnsAsync((Order?)null);

        //Act
        var result = await OrderEndpointsV1.GetOrderByNumber("1000", mock.Object);

        //Assert
        Assert.IsType<Results<Ok<Order>, NotFound>>(result);
        var notFoundResult = (NotFound)result.Result;
        Assert.NotNull(notFoundResult);
    }
}