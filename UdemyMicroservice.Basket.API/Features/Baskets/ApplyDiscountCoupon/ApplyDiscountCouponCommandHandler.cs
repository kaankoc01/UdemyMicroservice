using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservice.Basket.API.Const;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.API.Features.Baskets.ApplyDiscountCoupon
{
    public class ApplyDiscountCouponCommandHandler(IIdentityService identityService,BasketService basketService) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
        {
			

			var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);

			if (string.IsNullOrEmpty(basketAsJson))
			{
				return ServiceResult.Error("Basket Not Found",System.Net.HttpStatusCode.NotFound);
			}
			var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

			if (!basket.Items.Any())
			{
				return ServiceResult.Error("Basket item not found", System.Net.HttpStatusCode.NotFound);
			}

			basket.ApplyNewDiscount(request.Coupon, request.DiscountRate);

			basketAsJson = JsonSerializer.Serialize(basket);

			await basketService.CreateBasketCacheAsync(basket,cancellationToken);

			return ServiceResult.SuccessAsNoContent();
		}
    }
}
