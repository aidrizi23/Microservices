using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Models.Dto;
using Mango.Services.CouponApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponApiController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpGet]
        [Route("GetCoupons")]
        public async Task<ActionResult<CommonResponseDto<IEnumerable<Coupon>>>> GetCoupons()
        {
            var _commonResponse = new CommonResponseDto<IEnumerable<Coupon>>();
            var coupons = await _couponRepository.GetCouponsAsync();
            _commonResponse.Result = coupons;
            return Ok(_commonResponse.Result);
        }

        [HttpGet]
        [Route("GetCouponById/{id}")]
        public async Task<ActionResult<CommonResponseDto<Coupon>>> GetCouponById(int id)
        {
            var commonResponse = new CommonResponseDto<Coupon>();
            var coupon = await _couponRepository.GetCouponByiDAsync(id);
            if (coupon == null)
            {
                commonResponse.IsSuccess = false;
                commonResponse.ErrorMessage = "Coupon not found";
                return NotFound(commonResponse);
            }
            commonResponse.Result = coupon;
            return Ok(commonResponse.Result);
        }

        [HttpGet]
        [Route("GetCouponByCode/{code}")]
        public async Task<ActionResult<CommonResponseDto<Coupon>>> GetCouponByCodeAsync(string code)
        {
            var commonResponse = new CommonResponseDto<Coupon>();

            try
            {
                var coupon = await _couponRepository.GetCouponByCodeAsync(code);
                commonResponse.Result = coupon;
                if(coupon == null)
                {
                    commonResponse.Result = null;
                    commonResponse.IsSuccess = false;
                    commonResponse.ErrorMessage = "Coupon not found";
                    return NotFound(commonResponse);
                }
            }

            catch (Exception e)
            {
                commonResponse.IsSuccess = false;
                commonResponse.ErrorMessage = e.Message;
                return NotFound(commonResponse);
            }
            return Ok(commonResponse.Result);

        }

        [HttpPost]
        [Route("CreateCoupon")]
        public async Task<ActionResult<CommonResponseDto<Coupon>>> CreateCouponAsync([FromBody] CouponDto dto)
        {
            var coupon = new Coupon()
            {
                CouponCode = dto.CouponCode,
                DiscountAmount = dto.DiscountAmount,
                MinAmount = dto.MinAmount
            };

            var comonResopnse = new CommonResponseDto<Coupon>();
            try
            {
                await _couponRepository.CreateCouponAsync(coupon);
                comonResopnse.Result = coupon;
                if (coupon == null)
                {
                    comonResopnse.IsSuccess = false;
                    comonResopnse.ErrorMessage = "Coupon not created";
                    return NotFound(comonResopnse);

                }
                return Ok(comonResopnse.Result);
            }
            catch (Exception e)
            {
                comonResopnse.IsSuccess = false;
                comonResopnse.ErrorMessage = e.Message;
                return NotFound(comonResopnse);
            }
        }


        [HttpPut]
        [Route("UpdateCoupon")]
        public async Task<ActionResult<CommonResponseDto<Coupon>>> UpdateCoupon([FromBody] CouponDto dto)
        {
            var coupon = new Coupon()
            {
                CouponId = dto.CouponId,
                CouponCode = dto.CouponCode,
                DiscountAmount = dto.DiscountAmount,
                MinAmount = dto.MinAmount
            };

            var comonResopnse = new CommonResponseDto<Coupon>();
            try
            {
                await _couponRepository.UpdateCouponAsync(coupon);
                comonResopnse.Result = coupon;
                if (coupon == null)
                {
                    comonResopnse.IsSuccess = false;
                    comonResopnse.ErrorMessage = "Coupon not updated";
                    return NotFound(comonResopnse);

                }
                return Ok(comonResopnse.Result);
            }
            catch (Exception e)
            {
                comonResopnse.IsSuccess = false;
                comonResopnse.ErrorMessage = e.Message;
                return NotFound(comonResopnse);
            }
        }
    }
}
