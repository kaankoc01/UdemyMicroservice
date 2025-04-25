﻿namespace UdemyMicroservice.Catalog.API.Features.Courses.Update
{
    public record UpdateCourseCommand(Guid Id, string Name, string Description, decimal Price, Guid CategoryId, string? ImageUrl) : IRequestByServiceResult;
    
}