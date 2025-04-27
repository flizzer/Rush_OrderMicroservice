using Microsoft.EntityFrameworkCore;

namespace OrderAPI.Data;

public class OrderDBContext : DbContext
{
    public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options) {}

    public DbSet<Order> Orders => Set<Order>(); 
}
