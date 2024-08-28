using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<CommonResponseDto> GetAllCoupons();
        Task<CommonResponseDto> GetCouponById(int couponId);
        Task<CommonResponseDto> CreateCoupon(CouponDto coupon);
        Task<CommonResponseDto> UpdateCoupon(CouponDto coupon);
        Task<CommonResponseDto> DeleteCoupon(int couponId);

    }   
}
