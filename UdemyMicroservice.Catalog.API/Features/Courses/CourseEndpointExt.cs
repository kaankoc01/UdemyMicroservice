using UdemyMicroservice.Catalog.API.Features.Courses.Create;
using UdemyMicroservice.Catalog.API.Features.Courses.GetAll;
using UdemyMicroservice.Catalog.API.Features.Courses.GetById;

namespace UdemyMicroservice.Catalog.API.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/courses").WithTags("Courses")
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetCourseByIdGroupItemEndpoint();

        }
    }
}
