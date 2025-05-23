﻿
using UdemyMicroservice.Catalog.API.Repositories;

namespace UdemyMicroservice.Catalog.API.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await context.Categories
                .AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (existCategory)
            {
                return ServiceResult<CreateCategoryResponse>.Error("Category Name already exists", $"The Category name'{request.Name}' already exists",HttpStatusCode.BadRequest);
            }
            var category = new Category()
            {
                Name = request.Name,
                Id = NewId.NextSequentialGuid()
            };
            await context.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

           return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id),"<empty>");

        }
    }
}
