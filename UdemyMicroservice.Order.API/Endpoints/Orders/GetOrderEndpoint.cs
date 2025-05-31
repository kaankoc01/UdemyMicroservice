using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservice.Order.Application.Features.Orders.GetOrders;
using UdemyMicroservice.Shared.Extensions;
namespace UdemyMicroservice.Order.API.Endpoints.Orders
{
	public static class GetOrderEndpoint
	{
		public static RouteGroupBuilder GetOrderGroupItemEndpoint(this RouteGroupBuilder group)
		{
			group.MapGet("/",
				async (IMediator mediator) =>
				(await mediator.Send(new GetOrdersQuery())).ToGenericResult())
				.WithName("GetOrder")
				.MapToApiVersion(1, 0)
				.Produces<Guid>(StatusCodes.Status201Created)
				.Produces(StatusCodes.Status404NotFound)
				.Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
				.Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

			return group;
		}
	}
}
