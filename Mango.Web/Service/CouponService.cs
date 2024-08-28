using Mango.Web.Models;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<CommonResponseDto> GetAllCoupons()
        {
            // Implementation here
            return _baseService.SendAsync(new RequestDto { /* parameters */ });
        }

        public Task<CommonResponseDto> GetCouponById(int couponId)
        {
            // Implementation here
            return _baseService.SendAsync(new RequestDto { /* parameters */ });
        }

        public Task<CommonResponseDto> CreateCoupon(CouponDto coupon)
        {
            // Implementation here
            return _baseService.SendAsync(new RequestDto { /* parameters */ });
        }

        public Task<CommonResponseDto> UpdateCoupon(CouponDto coupon)
        {
            // Implementation here
            return _baseService.SendAsync(new RequestDto { /* parameters */ });
        }

        public Task<CommonResponseDto> DeleteCoupon(int couponId)
        {
            // Implementation here
            return _baseService.SendAsync(new RequestDto { /* parameters */ });
        }
    }
}
