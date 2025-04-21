using AutoMapper;
using UdemyMicroservice.Catalog.API.Features.Categories.Dtos;

namespace UdemyMicroservice.Catalog.API.Features.Categories
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
