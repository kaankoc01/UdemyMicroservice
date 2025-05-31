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
                async (CreateDiscountCommand command, IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
                .WithName("CreateDiscount")
                .MapToApiVersion(1,0)
                .Produces<Guid>(StatusCodes.Status201Created)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
                .AddEndpointFilter<ValidationFilter<CreateDiscountCommand>>();
                
            return group;
        }
    }
}
