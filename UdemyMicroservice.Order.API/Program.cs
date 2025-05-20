using Microsoft.EntityFrameworkCore;
using UdemyMicroservice.Order.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();


builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.Run();

