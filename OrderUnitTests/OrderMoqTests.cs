using OrderAPI;
using OrderAPI.Data;
using OrderAPI.Services;

namespace OrderUnitTests;

public class OrderMoqTests
{

    [Fact]
    public async Task OrderService_GetAllOrders_Returns_Orders()
    {
        //Arrange
        var mock = new Mock<IOrderService>();
        mock.Setup(mock => mock.GetAllOrders)
            .ReturnsAsync(new List<Order>{
                new Order
                {
                    Id = 1,
                    CustomerId = 2,
                    OrderNumber = null,
                    Total = null,
                    CreatedDate = DateTime.Now(),
                    Status = OrderStatus.Pending
                },
                new Order
                {
                   Id = 2,
                    CustomerId = 50,
                    OrderNumber = 1001,
                    Total = 100.00,
                    CreatedDate = DateTime.Now(),
                    Status = OrderStatus.Billed 
                }
            })
        
        //Act
        var result = await OrderEndpointsV1.GetAllOrders(mock.Object)

        //Assert
    }

}