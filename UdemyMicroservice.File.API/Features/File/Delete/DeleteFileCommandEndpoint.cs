using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservice.File.API.Features.File.Upload;
using UdemyMicroservice.Shared.Extensions;

namespace UdemyMicroservice.File.API.Features.File.Delete
{
	public static class DeleteFileCommandEndpoint
	{
		public static RouteGroupBuilder DeleteFileGroupItemEndpoint(this RouteGroupBuilder group)
		{
			group.MapPost("/{fileName}",
				async (string fileName, IMediator mediator) =>
				(await mediator.Send(new DeleteFileCommand(fileName))).ToGenericResult())
				.WithName("delete")
				.MapToApiVersion(1, 0)
				.Produces<Guid>(StatusCodes.Status201Created)
				.Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
				.Produces<ProblemDetails>(StatusCodes.Status404NotFound);

			return group;
		}
	}
}
