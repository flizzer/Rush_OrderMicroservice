using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.Services;
using Rush_OrderMicroservice;

var builder = WebApplication.CreateBuilder(args);

//DI the OrderService -- bhd
builder.Services.AddTransient<IOrderService, OrderService>();

//for EFCore InMemory usage -- bhd
builder.Services.AddDbContext<OrderDBContext>(opt => opt.UseInMemoryDatabase("Orders"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//for Swagger usage --bhd
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "OrderAPI";
    config.Title = "OrderAPI v1";
    config.Version = "v1";
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "OrderAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

//app.MapGet("/", () => "Hello World!");

var orders = app.MapGroup("/orders/v1").MapOrdersAPIV1();

// orders.MapGet("/", async (OrderDBContext orderDBContext) => 
//     await orderDBContext.Orders.ToListAsync());

app.Run();
