using Microsoft.EntityFrameworkCore;
using OrderService.DataAccess.Entities;

namespace OrderService.DataAccess
{
    public class OrderContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("order_schema");

            modelBuilder.Entity<Order>()
                        .ToTable("order", "order_schema")
                        .Property(order => order.id)
                        .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=localhost;Port=5432;Database=knitting;Username=admin;Password=1");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Order> Orders { get; set; }
    }
}