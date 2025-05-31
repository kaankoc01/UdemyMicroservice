using Microsoft.EntityFrameworkCore;
using UdemyMicroservice.Order.API;
using UdemyMicroservice.Order.API.Endpoints.Orders;
using UdemyMicroservice.Order.Application;
using UdemyMicroservice.Order.Application.Contracts.Repositories;
using UdemyMicroservice.Order.Application.Contracts.UnitOfWorks;
using UdemyMicroservice.Order.Persistence;
using UdemyMicroservice.Order.Persistence.Repositories;
using UdemyMicroservice.Order.Persistence.UnitOfWork;
using UdemyMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCommonServiceExt(typeof(OrderApplicationAssembly));
builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVersioningExt();



var app = builder.Build();

app.AddOrderGroupEndpointExt(app.AddVersionSetExt());

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.Run();

