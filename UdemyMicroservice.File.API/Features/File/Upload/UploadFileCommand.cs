using UdemyMicroservice.Shared;

namespace UdemyMicroservice.File.API.Features.File.Upload
{
	public record UploadFileCommand(IFormFile file) : IRequestByServiceResult<UploadFileCommandResponse>;

	
}
