using Asp.Versioning.Builder;
using UdemyMicroservice.Catalog.API.Features.Courses.Create;


namespace UdemyMicroservice.Catalog.API.Features.Courses
{
    public static class DiscountEndpointExt
    {
        public static void AddDiscountGroupEndpointExt(this WebApplication app,ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/discounts").WithTags("discounts").WithApiVersionSet(apiVersionSet)
                .CreateDiscountGroupItemEndpoint();
 

        }
    }
}
