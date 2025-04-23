namespace UdemyMicroservice.Catalog.API.Features.Courses.Create
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>().ReverseMap();
        }
    }
}
