using Asp.Versioning.Builder;
using UdemyMicroservice.Catalog.API.Features.Courses.Create;
using UdemyMicroservice.Catalog.API.Features.Courses.Delete;
using UdemyMicroservice.Catalog.API.Features.Courses.GetAll;
using UdemyMicroservice.Catalog.API.Features.Courses.GetAllByUserId;
using UdemyMicroservice.Catalog.API.Features.Courses.GetById;
using UdemyMicroservice.Catalog.API.Features.Courses.Update;

namespace UdemyMicroservice.Catalog.API.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app,ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/courses").WithTags("Courses").WithApiVersionSet(apiVersionSet)
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetCourseByIdGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint()
                .GetByUserIdCourseGroupItemEndpoint();

        }
    }
}
