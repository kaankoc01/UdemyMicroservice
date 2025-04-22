using UdemyMicroservice.Catalog.API.Features.Categories.Create;
using UdemyMicroservice.Catalog.API.Features.Categories.GetAll;
using UdemyMicroservice.Catalog.API.Features.Categories.GetById;

namespace UdemyMicroservice.Catalog.API.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/categories")
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint()
                .GetByIdCategoryGroupItemEndpoint();
        } 
    }
}
