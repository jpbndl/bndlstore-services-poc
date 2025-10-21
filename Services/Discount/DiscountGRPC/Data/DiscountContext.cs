using DiscountGRPC.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscountGRPC.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "Piecos Pizza", Description = "Piecos Pizza Discount", Amount = 150 },
                new Coupon { Id = 2, ProductName = "Dreamers Pizza", Description = "Dreamers Pizza Discount", Amount = 120 }
            );
        }
    }
}
