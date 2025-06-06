﻿using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservice.Basket.API.Const;
using UdemyMicroservice.Basket.API.Features.Baskets.GetBasket;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Extensions;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.API.Features.Baskets.RemoveDiscountCoupon
{
	public record RemoveDiscountCouponCommand : IRequestByServiceResult;

	public class RemoveDiscountCouponCommandHandler(IIdentityService identityService,BasketService basketService) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResult>
	{
		public async Task<ServiceResult> Handle(RemoveDiscountCouponCommand request, CancellationToken cancellationToken)
		{
		
			var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);

			if (string.IsNullOrEmpty(basketAsJson))
			{
				return ServiceResult.Error("Basket not found", System.Net.HttpStatusCode.NotFound);
			}
			var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

			basket!.ClearDiscount();

			basketAsJson = JsonSerializer.Serialize(basket);

			await basketService.CreateBasketCacheAsync(basket, cancellationToken);

			return ServiceResult.SuccessAsNoContent();
		}
	}

	public static class RemoveDiscountCouponEndpoint
	{
		public static RouteGroupBuilder RemoveDiscountCouponGroupItemEndpoint(this RouteGroupBuilder group)
		{
			group.MapDelete("/remove-discount-coupon",
				async (IMediator mediator) =>
					(await mediator.Send(new RemoveDiscountCouponCommand())).ToGenericResult())
				.WithName("RemoveDiscountCoupon")
				.MapToApiVersion(1, 0);

			return group;
		}
	}
}
