using Asp.Versioning.Builder;
using UdemyMicroservice.File.API.Features.Courses.Create;
using UdemyMicroservice.File.API.Features.File.Delete;

namespace UdemyMicroservice.File.API.Features.Courses
{
    public static class FileEndpointExt
    {
        public static void AddFileGroupEndpointExt(this WebApplication app,ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/files").WithTags("files").WithApiVersionSet(apiVersionSet)
                .UploadFileGroupItemEndpoint()
                .DeleteFileGroupItemEndpoint();
        }
    }
}
