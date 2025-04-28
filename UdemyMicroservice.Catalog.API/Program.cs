using UdemyMicroservice.Catalog.API;
using UdemyMicroservice.Catalog.API.Features.Categories;
using UdemyMicroservice.Catalog.API.Features.Courses;
using UdemyMicroservice.Catalog.API.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));


var app = builder.Build();

app.AddSeedDataExt().ContinueWith(x =>
{
    if (!x.IsFaulted)
    {
        Console.WriteLine("Seed data added successfully.");
    }
    else
    {
        Console.WriteLine(x.Exception?.Message);
    }
});

app.AddCategoryGroupEndpointExt();
app.AddCourseGroupEndpointExt();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

