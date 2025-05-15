using UdemyMicroservice.Shared;

namespace UdemyMicroservice.File.API.Features.File.Delete
{
	public record DeleteFileCommand(string FileName) : IRequestByServiceResult;
	
}
