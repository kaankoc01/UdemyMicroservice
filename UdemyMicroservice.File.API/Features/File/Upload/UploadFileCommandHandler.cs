using MediatR;
using Microsoft.Extensions.FileProviders;
using UdemyMicroservice.Shared;

namespace UdemyMicroservice.File.API.Features.File.Upload
{
	public class UploadFileCommandHandler(IFileProvider fileProvider) : IRequestHandler<UploadFileCommand, ServiceResult<UploadFileCommandResponse>>
	{
		public Task<ServiceResult<UploadFileCommandResponse>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
