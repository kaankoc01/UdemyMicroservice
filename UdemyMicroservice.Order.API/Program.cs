using Microsoft.EntityFrameworkCore;
using UdemyMicroservice.Order.Application.Contracts.Repositories;
using UdemyMicroservice.Order.Persistence;
using UdemyMicroservice.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();


builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddScoped(typeof(IGenericRepository<,>),typeof(GenericRepository<,>));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.Run();

