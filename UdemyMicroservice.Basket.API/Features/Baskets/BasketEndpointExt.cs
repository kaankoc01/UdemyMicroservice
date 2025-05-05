using Asp.Versioning.Builder;
using UdemyMicroservice.Basket.API.Features.Baskets.AddBasketItem;
using UdemyMicroservice.Basket.API.Features.Baskets.ApplyDiscountCoupon;
using UdemyMicroservice.Basket.API.Features.Baskets.DeleteBasketItem;
using UdemyMicroservice.Basket.API.Features.Baskets.GetBasket;
using UdemyMicroservice.Basket.API.Features.Baskets.RemoveDiscountCoupon;

namespace UdemyMicroservice.Basket.API.Features.Baskets
{
    public static class BasketEndpointExt
    {
        public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
                .WithApiVersionSet(apiVersionSet)
                .AddBasketItemGroupItemEndpoint()
                .DeleteBasketItemGroupItemEndpoint()
                .GetBasketGroupItemEndpoint()
                .ApplyDiscountCouponGroupItemEndpoint()
                .RemoveDiscountCouponGroupItemEndpoint();
        }
    }
}
