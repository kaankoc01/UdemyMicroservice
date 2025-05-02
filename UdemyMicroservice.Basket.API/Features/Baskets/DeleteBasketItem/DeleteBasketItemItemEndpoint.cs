using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservice.Shared.Extensions;
using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Basket.API.Features.Baskets.DeleteBasketItem
{
    public static class DeleteBasketItemItemEndpoint
    {
        public static RouteGroupBuilder DeleteBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/item/{id:guid}",
                async (Guid id, IMediator mediator) =>
                (await mediator.Send(new DeleteBasketItemCommand(id))).ToGenericResult())
                .WithName("DeleteBasketItem")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
