using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservice.Basket.API.Const;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.API.Features.Baskets
{
	public class BasketService(IIdentityService identityService , IDistributedCache distributedCache)
	{
		private string GetCacheKey () => string.Format(BasketConst.BasketCacheKey, identityService.GetUserId);

		public async Task<string?> GetBasketFromCache(CancellationToken cancellationToken)
		{
			
			return await distributedCache.GetStringAsync(GetCacheKey(),token: cancellationToken);

		}
		public async Task CreateBasketCacheAsync(Data.Basket basket,  CancellationToken cancellationToken)
		{
			var basketAsString = JsonSerializer.Serialize(basket);

			await distributedCache.SetStringAsync(GetCacheKey(), basketAsString);
		}

	}
}
