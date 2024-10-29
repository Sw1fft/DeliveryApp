using Microsoft.EntityFrameworkCore;
using DeliveryWebApp.Models;

namespace DeliveryWebApp.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(builder =>
            {
                builder.HasKey(o => o.Id);

                builder.Property(o => o.CityDistrict).HasMaxLength(100);
            });
        }
    }
}
