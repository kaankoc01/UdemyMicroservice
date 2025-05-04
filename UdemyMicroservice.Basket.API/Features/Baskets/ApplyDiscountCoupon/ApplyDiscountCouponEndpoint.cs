using MediatR;
using UdemyMicroservice.Basket.API.Features.Baskets.AddBasketItem;
using UdemyMicroservice.Shared.Extensions;
using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Basket.API.Features.Baskets.ApplyDiscountCoupon
{
    public static class ApplyDiscountCouponEndpoint
    {
		public static RouteGroupBuilder ApplyDiscountCouponGroupItemEndpoint(this RouteGroupBuilder group)
		{
			group.MapPut("/apply-discount-rate",
				async (ApplyDiscountCouponCommand Command, IMediator mediator) =>
				(await mediator.Send(Command)).ToGenericResult())
				.WithName("ApplyDiscountRate")
				.MapToApiVersion(1, 0)
				.AddEndpointFilter<ValidationFilter<ApplyDiscountCouponCommandValidator>>();

			return group;
		}
	}
}
