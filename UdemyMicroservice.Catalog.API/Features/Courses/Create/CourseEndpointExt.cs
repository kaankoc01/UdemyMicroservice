namespace UdemyMicroservice.Catalog.API.Features.Courses.Create
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/courses").WithTags("Courses").CreateCourseGroupItemEndpoint();

        }
    }
}
