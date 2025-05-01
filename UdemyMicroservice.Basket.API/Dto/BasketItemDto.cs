namespace UdemyMicroservice.Basket.API.Dto
{
    public record BasketItemDto(Guid Id, string Name, string imageUrl, decimal Price, decimal? PriceByApplyDiscountRate);

}
