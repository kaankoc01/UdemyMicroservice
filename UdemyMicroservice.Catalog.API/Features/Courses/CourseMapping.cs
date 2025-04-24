﻿using UdemyMicroservice.Catalog.API.Features.Courses.Create;
using UdemyMicroservice.Catalog.API.Features.Courses.Dtos;

namespace UdemyMicroservice.Catalog.API.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
