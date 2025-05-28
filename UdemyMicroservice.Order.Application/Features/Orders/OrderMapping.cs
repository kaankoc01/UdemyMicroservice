using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
