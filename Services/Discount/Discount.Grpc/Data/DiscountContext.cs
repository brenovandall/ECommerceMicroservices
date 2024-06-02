using Bogus;
using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options) {  }

    public DbSet<Coupon> Coupons { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, Description = "Smartwatch Coupon", ProductName = "Smartwatch", Amount = 50 },
                new Coupon { Id = 2, Description = "Wireless Earbuds Coupon", ProductName = "Wireless Earbuds", Amount = 15 }
            );
    }
}
