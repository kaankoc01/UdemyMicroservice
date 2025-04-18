using UdemyMicroservice.Catalog.API.Features.Courses;
using UdemyMicroservice.Catalog.API.Repositories;

namespace UdemyMicroservice.Catalog.API.Features.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default;
        public List<Course>? Courses { get; set; }
    }
}
