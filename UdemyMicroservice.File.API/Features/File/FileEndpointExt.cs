using Asp.Versioning.Builder;



namespace UdemyMicroservice.Catalog.API.Features.Courses
{
    public static class FileEndpointExt
    {
        public static void AddDiscountGroupEndpointExt(this WebApplication app,ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/files").WithTags("files").WithApiVersionSet(apiVersionSet);
 

        }
    }
}
