using Microsoft.EntityFrameworkCore;
using Orders.Domain.Models;
using Orders.Repository.Configuration;

namespace Orders.Repository.Context;

public class OrdersContext : DbContext
{
    public OrdersContext(DbContextOptions<OrdersContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new OrderConfiguration());
    }
}
