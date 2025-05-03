using AutoMapper;

namespace UdemyMicroservice.Basket.API.Features.Baskets
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Dto.BasketItemDto, Data.BasketItem>().ReverseMap();
            CreateMap<Dto.BasketDto, Data.Basket>().ReverseMap();
        }
    }
}
