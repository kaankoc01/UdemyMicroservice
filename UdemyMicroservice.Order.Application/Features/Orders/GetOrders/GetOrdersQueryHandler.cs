using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyMicroservice.Order.Application.Contracts.Repositories;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Order.Application.Features.Orders.GetOrders
{
	public class GetOrdersQueryHandler(IIdentityService identityService,IOrderRepository orderRepository): IRequestHandler<GetOrdersQuery, ServiceResult<List<GetOrdersResponse>>
	{
		public async Task<ServiceResult<List<GetOrdersResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
		{
			var orders = await orderRepository.GetOrderByUserId(identityService.GetUserId);
		}
	}
}
