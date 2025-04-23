using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Catalog.API.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                async (CreateCategoryCommand Command, IMediator mediator) => 
                (await mediator.Send(Command)).ToGenericResult())
                .WithName("CreateCategory")
                .Produces<Guid>(StatusCodes.Status201Created)

                .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();


            return group;
        }
    }
}
