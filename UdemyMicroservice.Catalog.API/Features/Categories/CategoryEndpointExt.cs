using UdemyMicroservice.Catalog.API.Features.Categories.Create;

namespace UdemyMicroservice.Catalog.API.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/categories").CreateCategoryGroupItemEndpoint();
        } 
    }
}
