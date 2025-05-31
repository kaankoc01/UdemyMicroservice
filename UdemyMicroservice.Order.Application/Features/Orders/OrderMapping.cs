using AutoMapper;
using UdemyMicroservice.Order.Application.Features.Orders.Create;
using UdemyMicroservice.Order.Domain.Entity;

namespace UdemyMicroservice.Order.Application.Features.Orders
{
    public class OrderMapping : Profile
    {
		public OrderMapping()
		{
			CreateMap<OrderItem, OrderItemDto>().ReverseMap();
		}
	}
}
