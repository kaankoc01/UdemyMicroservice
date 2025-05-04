using UdemyMicroservice.Shared;

namespace UdemyMicroservice.Basket.API.Features.Baskets.ApplyDiscountCoupon
{
	public record ApplyDiscountCouponCommand(string Coupon, float DiscountRate) : IRequestByServiceResult;
}
