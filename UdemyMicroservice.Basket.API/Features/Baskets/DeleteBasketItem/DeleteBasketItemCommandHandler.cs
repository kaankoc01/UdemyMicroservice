using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.API.Features.Baskets.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler(IIdentityService identityService,BasketService basketService) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {

            var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);


			if (string.IsNullOrEmpty(basketAsJson))
            {
                return ServiceResult.Error("Basket Not Found", System.Net.HttpStatusCode.NotFound);
            }

            var currentBasket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

            var basketItemToDelete = currentBasket!.Items.FirstOrDefault(x => x.Id == request.Id);

            if (basketItemToDelete is null)
            {
                return ServiceResult.Error("Basket Item Not Found", System.Net.HttpStatusCode.NotFound);
            }
            currentBasket.Items.Remove(basketItemToDelete);

			basketAsJson = JsonSerializer.Serialize(currentBasket);

            await basketService.CreateBasketCacheAsync(currentBasket, cancellationToken);

			return ServiceResult.SuccessAsNoContent();


        }
    }
}
