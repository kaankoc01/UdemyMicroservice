using UdemyMicroservice.Shared;

namespace UdemyMicroservice.Basket.API.Features.Baskets.DeleteBasketItem
{
    public record DeleteBasketItemCommand(Guid Id) : IRequestByServiceResult;
}
