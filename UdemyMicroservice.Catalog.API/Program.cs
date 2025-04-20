using UdemyMicroservice.Catalog.API;
using UdemyMicroservice.Catalog.API.Features.Categories;
using UdemyMicroservice.Catalog.API.Options;
using UdemyMicroservice.Catalog.API.Repositories;
using UdemyMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));


var app = builder.Build();

app.AddCategoryGroupEndpointExt();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

