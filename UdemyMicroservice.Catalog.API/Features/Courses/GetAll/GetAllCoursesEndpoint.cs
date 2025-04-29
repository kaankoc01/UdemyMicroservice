using UdemyMicroservice.Catalog.API.Features.Courses.Create;
using UdemyMicroservice.Catalog.API.Features.Courses.Dtos;
using UdemyMicroservice.Shared.Filters;

namespace UdemyMicroservice.Catalog.API.Features.Courses.GetAll
{
    public class GetAllCoursesQuery() : IRequestByServiceResult<List<CourseDto>>;

    public class GetALlCoursesQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.ToListAsync(cancellationToken);
            var categories = await context.Categories.ToListAsync(cancellationToken);
            foreach (var course in courses)
            {
                course.Category = categories.First(x => x.Id == course.CategoryId);
            }
            var courseDtos = mapper.Map<List<CourseDto>>(courses);
            return ServiceResult<List<CourseDto>>.SuccessAsOk(courseDtos);
        }
    }
    public static class GetAllCoursesEndpoint
    {
        public static RouteGroupBuilder GetAllCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/",
                async (IMediator mediator) =>
                (await mediator.Send(new GetAllCoursesQuery())).ToGenericResult())
                .MapToApiVersion(1, 0)
                .WithName("GetAllCourse");
            return group;
        }
    }
}
