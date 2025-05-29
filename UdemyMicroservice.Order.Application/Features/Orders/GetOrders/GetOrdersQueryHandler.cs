using AutoMapper;
using MediatR;
using UdemyMicroservice.Order.Application.Contracts.Repositories;
using UdemyMicroservice.Order.Application.Features.Orders.Create;
using UdemyMicroservice.Shared;
using UdemyMicroservice.Shared.Services;

namespace UdemyMicroservice.Order.Application.Features.Orders.GetOrders
{
	public class GetOrdersQueryHandler(IIdentityService identityService,IOrderRepository orderRepository,IMapper mapper): IRequestHandler<GetOrdersQuery, ServiceResult<List<GetOrdersResponse>>
	{
		public async Task<ServiceResult<List<GetOrdersResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
		{
			var orders = await orderRepository.GetOrderByUserId(identityService.GetUserId);

			var response = orders.Select(o => new GetOrdersResponse(o.Created, o.TotalPrice, mapper.Map<List<OrderItemDto>>(o.OrderItems))).ToList();

			return ServiceResult<List<GetOrdersResponse>>.SuccessAsOk(response);

		}
	}
}
