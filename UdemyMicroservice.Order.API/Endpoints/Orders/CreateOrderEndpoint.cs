using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservice.Order.Application.Features.Orders.Create;

namespace UdemyMicroservice.Order.API.Endpoints.Orders
{
	public static class CreateOrderEndpoint
	{
		public static RouteGroupBuilder CreateOrderGroupItemEndpoint(this RouteGroupBuilder group)
		{
			group.MapPost("/",
				async ([FromBody] CreateOrderCommand Command, [FromServices] IMediator mediator) =>
				(await mediator.Send(Command)).ToGenericResult())
				.WithName("CreateOrder")
				.MapToApiVersion(1, 0)
				.Produces<Guid>(StatusCodes.Status201Created)
				.Produces(StatusCodes.Status404NotFound)
				.Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
				.Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
			//	.AddEndpointFilter<ValidationFilter<CreateOrderCommand>>()

			return group;
		}
	}
}
