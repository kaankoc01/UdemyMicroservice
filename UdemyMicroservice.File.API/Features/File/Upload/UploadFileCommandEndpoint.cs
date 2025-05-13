using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservice.File.API.Features.File.Upload;
using UdemyMicroservice.Shared.Extensions;

namespace UdemyMicroservice.Catalog.API.Features.Courses.Create
{
    public static class UploadFileCommandEndpoint
    {
        public static RouteGroupBuilder UploadFileGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                async (UploadFileCommand command, IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
                .WithName("upload")
                .MapToApiVersion(1, 0)
                .Produces<Guid>(StatusCodes.Status201Created)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status404NotFound);
                
            return group;
        }
    }
}
