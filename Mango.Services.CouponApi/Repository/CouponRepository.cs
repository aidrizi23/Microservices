using Mango.Services.CouponApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponApi.Repository
{
    // we will not be using the servoce layer for this one se po pertoj keq fare but we will use rpository pattern so that i will implement some of my own knowledge
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _context;

        public CouponRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Coupon>> GetCouponsAsync()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task<Coupon> GetCouponByiDAsync(int id)
        {
            return await _context.Coupons.FirstOrDefaultAsync(u => u.CouponId == id);
        }
    

        public async Task<Coupon> GetCouponByCodeAsync(string code)
        {
            return await _context.Coupons.FirstOrDefaultAsync(u => u.CouponCode == code);
        }

        // method to create another coupon
        public async Task CreateCouponAsync(Coupon coupon)
        {
            await _context.Coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCouponAsync(Coupon coupon)
        {
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
        }
    }

    public interface ICouponRepository
    {
        Task<Coupon> GetCouponByiDAsync(int id);
        Task<IEnumerable<Coupon>> GetCouponsAsync();
        Task<Coupon> GetCouponByCodeAsync(string code);
        Task CreateCouponAsync(Coupon coupon);
        Task UpdateCouponAsync(Coupon coupon);
    }

}
