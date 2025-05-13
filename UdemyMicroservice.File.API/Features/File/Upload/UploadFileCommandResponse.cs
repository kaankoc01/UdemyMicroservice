using UdemyMicroservice.Shared;

namespace UdemyMicroservice.File.API.Features.File.Upload
{
	public record UploadFileCommandResponse(string FileName, string FilePath, string OriginalFileName);

}
