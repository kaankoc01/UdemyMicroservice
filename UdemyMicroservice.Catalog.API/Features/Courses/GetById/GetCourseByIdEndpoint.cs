using UdemyMicroservice.Catalog.API.Features.Courses.Dtos;
using UdemyMicroservice.Catalog.API.Features.Courses.GetAll;

namespace UdemyMicroservice.Catalog.API.Features.Courses.GetById
{
    public record GetCourseByIdQuery(Guid Id) : IRequestByServiceResult<CourseDto>;
    public class GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDto>>
    {
        public async Task<ServiceResult<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var hasCourse = await context.Courses
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (hasCourse is null)
            {
                return ServiceResult<CourseDto>.Error("Course not found", $"The course with id {request.Id} was not found", HttpStatusCode.NotFound);
            }
            var category = await context.Categories.FindAsync(hasCourse.CategoryId, cancellationToken);

            hasCourse.Category = category!;

            var courseDto = mapper.Map<CourseDto>(hasCourse);
            return ServiceResult<CourseDto>.SuccessAsOk(courseDto);
        }
    }
    public static class GetCourseByIdEndpoint
    {
        public static RouteGroupBuilder GetCourseByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}",
                async (IMediator mediator,Guid id) =>
                (await mediator.Send(new GetCourseByIdQuery(id))).ToGenericResult())
                .WithName("GetByIdCourse");
            return group;
        }
    }
}
