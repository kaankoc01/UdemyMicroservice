using Microsoft.AspNetCore.Mvc;
using UdemyMicroservice.Discount.API.Features.Discounts.CreateDiscount;
using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Catalog.API.Features.Courses.Create
{
    public static class CreateDiscountCommandEndpoint
    {
        public static RouteGroupBuilder CreateDiscountGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                async (CreateDiscountCommand Command, IMediator mediator) =>
                (await mediator.Send(Command)).ToGenericResult())
                .WithName("CreateDiscount")
                .MapToApiVersion(1,0)
                .Produces<Guid>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status404NotFound)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
                .AddEndpointFilter<ValidationFilter<CreateDiscountCommand>>();
                
            return group;
        }
    }
}
