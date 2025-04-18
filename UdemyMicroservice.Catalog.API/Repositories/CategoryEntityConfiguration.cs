using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using UdemyMicroservice.Catalog.API.Features.Categories;

namespace UdemyMicroservice.Catalog.API.Repositories
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Collection/Document/field
           builder.ToCollection("categories");
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Id).ValueGeneratedNever();
           builder.Ignore(x => x.Courses);

        }
    } 
}
