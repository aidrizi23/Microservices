using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        // now we will seed the database so that we do not start with an empty one
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Coupon>().HasData(new Coupon { CouponId = 1, CouponCode = "10OFF", DiscountAmount = 10, MinAmount = 100 });
            builder.Entity<Coupon>().HasData(new Coupon { CouponId = 2, CouponCode = "20OFF", DiscountAmount = 20, MinAmount = 200 });
            builder.Entity<Coupon>().HasData(new Coupon { CouponId = 3, CouponCode = "30OFF", DiscountAmount = 30, MinAmount = 300 });
            builder.Entity<Coupon>().HasData(new Coupon { CouponId = 4, CouponCode = "40OFF", DiscountAmount = 40, MinAmount = 400 });
            builder.Entity<Coupon>().HasData(new Coupon { CouponId = 5, CouponCode = "50OFF", DiscountAmount = 50, MinAmount = 500 }); // this is how u seed the tables
        }
    }
}
