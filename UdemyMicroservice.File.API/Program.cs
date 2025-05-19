using Microsoft.Extensions.FileProviders;
using UdemyMicroservice.File.API;
using UdemyMicroservice.File.API.Features.Courses;
using UdemyMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFileProvider>( new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));


builder.Services.AddCommonServiceExt(typeof(FileAssembly));
builder.Services.AddVersioningExt();


var app = builder.Build();
app.AddFileGroupEndpointExt(app.AddVersionSetExt());
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.MapOpenApi();
}

app.Run();

