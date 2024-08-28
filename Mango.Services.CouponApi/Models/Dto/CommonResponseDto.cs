namespace Mango.Services.CouponApi.Models.Dto
{
    public class CommonResponseDto<T>
    {
        public T? Result { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

    }
}
