namespace UdemyMicroservice.Catalog.API.Features.Courses.Dtos
{
    public record CourseDto(Guid Id, string Name, string Description, string ImageUrl, CategoryDto Category, decimal Price, FeatureDto Feature);
}
