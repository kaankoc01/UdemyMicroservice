using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservice.File.API.Features.File.Upload;
using UdemyMicroservice.Shared.Extensions;

namespace UdemyMicroservice.File.API.Features.Courses.Create
{
    public static class UploadFileCommandEndpoint
    {
        public static RouteGroupBuilder UploadFileGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                async (IFormFile file, IMediator mediator) =>
                (await mediator.Send(new UploadFileCommand(file))).ToGenericResult())
                .WithName("upload")
                .MapToApiVersion(1, 0)
                .Produces<Guid>(StatusCodes.Status201Created)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status404NotFound).DisableAntiforgery();
                
            return group;
        }
    }
}
