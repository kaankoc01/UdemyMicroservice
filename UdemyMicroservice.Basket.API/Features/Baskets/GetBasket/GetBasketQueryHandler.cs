using AutoMapper;
using MediatR;
using System.Text.Json;
using UdemyMicroservice.Basket.API.Dto;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Basket.API.Features.Baskets.GetBasket
{
    public class GetBasketQueryHandler(IIdentityService identityService,IMapper mapper,BasketService basketService) : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
    {
        public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            
            var basketAsString = await basketService.GetBasketFromCache(cancellationToken);
			if (string.IsNullOrEmpty(basketAsString))
            {
                return ServiceResult<BasketDto>.Error("Basket not found.", System.Net.HttpStatusCode.NotFound);
            }
            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);

            var basketDto = mapper.Map<BasketDto>(basket);

            return ServiceResult<BasketDto>.SuccessAsOk(basketDto);

        }
    }

}
